using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.DbContext;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    [Authorize(Roles="Radnik")]
    public class UspostaviDijagnozuController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private IDiagnoseRepository _diagnoseRepository;
        private IServiceRepository _serviceRepository;

        public UspostaviDijagnozuController(UserManager<ApplicationUser> userManager,
                                            IDiagnoseRepository diagnoseRepository,
                                            IServiceRepository serviceRepository,
                                            ApplicationDbContext context)
        {
            this.userManager = userManager;
            _diagnoseRepository = diagnoseRepository;
            _serviceRepository = serviceRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UspostaviDijagnozuViewModel model = new UspostaviDijagnozuViewModel();
            model.Diagnoses = _diagnoseRepository.GetDiagnoses().ToList();
            model.Services = _serviceRepository.GetServices().ToList();
            model.Patients = userManager.Users.ToList();
            for(int i=0;i< model.Patients.Count(); i++)
            {
                if (_context.Workers.SingleOrDefault(c => c.Id == model.Patients[i].Id) != null)
                    model.Patients.RemoveAt(i);
            }
                
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Detalji(string patientId)
        {
            UspostaviDijagnozuViewModel model = new UspostaviDijagnozuViewModel();
            model.Diagnoses = _diagnoseRepository.GetDiagnoses().ToList();
            model.Services = _serviceRepository.GetServices().ToList();
            model.Patients.Add( await userManager.FindByIdAsync(patientId));
            
            return View(model);
        }
    }
}