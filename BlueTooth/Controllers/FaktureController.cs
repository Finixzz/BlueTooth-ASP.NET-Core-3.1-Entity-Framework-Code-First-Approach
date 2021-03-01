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
    [Authorize(Roles ="ARadnik,Vlasnik,Admin")]
    public class FaktureController : Controller
    {
        private IBillRepository _billRepository;
        private IDentalCheckRepository _dentalCheckRepository;
        private _IDentalCheckServicesRepository _denentalCheckServicesRepository;
        private IServiceRepository _serviceRepository;
        private IAppointmentRepository _appointmentRepository;
        private UserManager<ApplicationUser> userManager;

        public FaktureController(IBillRepository _billRepository,
                                IDentalCheckRepository _dentalCheckRepository,
                                _IDentalCheckServicesRepository _denentalCheckServicesRepository,
                                IServiceRepository _serviceRepository,
                                IAppointmentRepository _appointmentRepository,
                                UserManager<ApplicationUser> userManager)
        {
            this._billRepository = _billRepository;
            this._dentalCheckRepository = _dentalCheckRepository;
            this._denentalCheckServicesRepository = _denentalCheckServicesRepository;
            this._serviceRepository = _serviceRepository;
            this._appointmentRepository = _appointmentRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult PrikaziFakture()
        {
            var fakture = _billRepository.GetBills().ToList();
            fakture.Sort((x, y) => DateTime.Compare(y.Time, x.Time));
            return View(fakture);
        }

        [HttpGet]
        public IActionResult Detalji(int id)
        {
            var faktura = _billRepository.GetBill(id);

            if (faktura == null)
                return BadRequest();
            PrikaziDetaljeFaktureViewModel model = new PrikaziDetaljeFaktureViewModel()
            {
                Id = faktura.Id,
                DentalCheckId = faktura.DentalCheckId,
                Time = faktura.Time,
                TotalPrice = faktura.TotalPrice
            };
            var usluge = _denentalCheckServicesRepository.GetDentalCheckServices(model.DentalCheckId);
            for(int i = 0; i < usluge.Services.Count(); i++)
            {
                model.Usluge.Add(_serviceRepository.GetService(usluge.Services[i]));
            }
            return View(model);
        }

        public async Task< IActionResult> Index()
        {
            List<UpostaviFakturuViewModel> modelList = new List<UpostaviFakturuViewModel>();
            var pregledi = _dentalCheckRepository.GetDentalChecks().ToList();
            var termini = _appointmentRepository.GetAppointments().ToList();
            var racuni = _billRepository.GetBills().ToList();


            
            for(int i = 0; i < pregledi.Count(); i++)
            {
                for(int j = 0; j < racuni.Count(); j++)
                {
                    if (pregledi[i].Id == racuni[j].DentalCheckId)
                        pregledi.RemoveAt(i);
                }
            }

            for(int i = 0; i < pregledi.Count(); i++)
            {
                UpostaviFakturuViewModel model = new UpostaviFakturuViewModel();
                
                    model.PregledId = pregledi[i].Id;
                
                
                for(int j = 0; j < termini.Count(); j++)
                {
                    if (termini[j].Id == pregledi[i].AppointmentId)
                        model.Pacijent = await userManager.FindByIdAsync(termini[j].PatientId);
                }
                _DentalCheckServices usluge = _denentalCheckServicesRepository.GetDentalCheckServices(pregledi[i].Id);
                for(int j = 0; j < usluge.Services.Count(); j++)
                {
                    model.Usluge.Add(_serviceRepository.GetService(usluge.Services[j]));
                    model.UkupnaCijena += model.Usluge[j].Price;
                }
                modelList.Add(model);
            }
            
            return View(modelList);
        }


        
    }
}