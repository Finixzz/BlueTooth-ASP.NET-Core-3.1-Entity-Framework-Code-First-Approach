using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.DbContext;
using BlueTooth.Models;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost][HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ModelState.Remove("model.BirthDate");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Pacijent");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                                    model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Index()
        {
            ApplicationUser user = _context.Users.SingleOrDefault(c => c.Id == userManager.GetUserId(User));
            LicniPodaciViewModel model = new LicniPodaciViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate.ToString("dd-MM-yyyy"),
                LastName = user.LastName,
                Gender = user.Gender
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult EditLicniPodaci(string userId)
        {
            ApplicationUser user = _context.Users.SingleOrDefault(c => c.Id == userManager.GetUserId(User));
            LicniPodaciViewModel model = new LicniPodaciViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate.ToString("dd-MM-yyyy"),
                LastName = user.LastName,
                Gender = user.Gender
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveChanges(LicniPodaciViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _context.Users.SingleOrDefault(c => c.Id == userManager.GetUserId(User));
                user.FirstName = model.FirstName;
                user.UserName = model.Email;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Gender = model.Gender;
                user.BirthDate = Convert.ToDateTime(model.BirthDate);
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            model.Id = userManager.GetUserId(User);
            return View("EditLicniPodaci", model);

        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }


    }
}
