using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.DbContext;
using BlueTooth.Models;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;


namespace BlueTooth.Controllers
{
    [Authorize(Roles ="Vlasnik,Admin")]
    public class OsobljeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> signInManager;

        public OsobljeController(UserManager<ApplicationUser> userManager,
                                IHostingEnvironment hostingEnvironment,
                                ApplicationDbContext context,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            _context = context;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var workersInDb = _context.Workers.ToList();
            List<RadnikCreateViewModel> modelList = new List<RadnikCreateViewModel>();
            for(int i = 0; i < users.Count(); i++)
            {
                for(int j = 0; j < workersInDb.Count(); j++)
                {
                    if (users[i].Id == workersInDb[j].Id && workersInDb[j].IsEmployed)
                    {
                        var user = await _userManager.FindByIdAsync(workersInDb[j].Id);
                        var worker = _context.Workers.SingleOrDefault(c => c.Id == workersInDb[j].Id);
                        RadnikCreateViewModel model = new RadnikCreateViewModel()
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            BirthDate = user.BirthDate.ToString("dd-MM-yyyy"),
                            Email = user.Email,
                            Gender = user.Gender,
                            Qualification = worker.Qualification,
                            CVPath = worker.CV
                        };
                        modelList.Add(model);
                    }
                }
            }
            return View(modelList);
        }

        [HttpGet]
        public IActionResult DodajRadnika()
        {
            RadnikCreateViewModel model = new RadnikCreateViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult DodajARadnika()
        {
            RadnikCreateViewModel model = new RadnikCreateViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task< IActionResult> Detalji(string workerId)
        {
            
            var user = await  _userManager.FindByIdAsync(workerId);
            if (!await _userManager.IsInRoleAsync(user, "Radnik") && !await _userManager.IsInRoleAsync(user, "ARadnik"))
                return BadRequest();
            if (user == null)
                return NotFound();

            Worker workerInDb = _context.Workers.SingleOrDefault(c => c.Id == workerId);
            RadnikCreateViewModel model = new RadnikCreateViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate.ToString("dd-MM-yyyy"),
                Email=user.Email,
                Gender = user.Gender,
                Qualification=workerInDb.Qualification,
                CVPath=workerInDb.CV
            };
            return View(model);
        }


        private Worker SaveWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
            return worker;
        }

        [HttpPost]
        public async Task<IActionResult >DodajRadnika(RadnikCreateViewModel model)
        {
            ModelState.Remove("radnik.Id");
            if (!ModelState.IsValid)
                return View(model);

            string uniqueFileName = null;
            if (model.CV != null)
            {
                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "CVRepo");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CV.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                model.CV.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = Convert.ToDateTime(model.BirthDate),
                Gender = model.Gender
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Radnik");
                Worker noviRadnik = new Worker()
                {
                    Id = user.Id,
                    Qualification= model.Qualification,
                    CV=uniqueFileName
                };
                if (noviRadnik.CV == null)
                    noviRadnik.CV = "N/A";
                SaveWorker(noviRadnik);
                model.Id = user.Id;
                return RedirectToAction("Detalji",new { workerId = user.Id });
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DodajARadnika(RadnikCreateViewModel model)
        {
            ModelState.Remove("radnik.Id");
            if (!ModelState.IsValid)
                return View(model);

            string uniqueFileName = null;
            if (model.CV != null)
            {
                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "CVRepo");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CV.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                model.CV.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = Convert.ToDateTime(model.BirthDate),
                Gender = model.Gender
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "ARadnik");
                Worker noviRadnik = new Worker()
                {
                    Id = user.Id,
                    Qualification = model.Qualification,
                    CV = uniqueFileName
                };
                if (noviRadnik.CV == null)
                    noviRadnik.CV = "N/A";
                SaveWorker(noviRadnik);
                model.Id = user.Id;
                return RedirectToAction("Detalji", new { workerId = user.Id });
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult OtpustiRadnika(string workerId)
        {
            var worker = _context.Workers.SingleOrDefault(c => c.Id == workerId);
            if (worker == null)
                return BadRequest();

            worker.IsEmployed = false;
            _context.SaveChanges();
           
            return RedirectToAction("index", "osoblje");
        }

        [HttpGet]
        public async Task<IActionResult> OtpusteniRadnici()
        {
            var users = _userManager.Users.ToList();
            var workersInDb = _context.Workers.ToList();
            List<RadnikCreateViewModel> modelList = new List<RadnikCreateViewModel>();
            for (int i = 0; i < users.Count(); i++)
            {
                for (int j = 0; j < workersInDb.Count(); j++)
                {
                    if (users[i].Id == workersInDb[j].Id && !workersInDb[j].IsEmployed)
                    {
                        var user = await _userManager.FindByIdAsync(workersInDb[j].Id);
                        var worker = _context.Workers.SingleOrDefault(c => c.Id == workersInDb[j].Id);
                        RadnikCreateViewModel model = new RadnikCreateViewModel()
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            BirthDate = user.BirthDate.ToString("dd-MM-yyyy"),
                            Email = user.Email,
                            Gender = user.Gender,
                            Qualification = worker.Qualification,
                            CVPath = worker.CV
                        };
                        modelList.Add(model);
                    }
                }
            }
            return View(modelList);
        }
    }
}