using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    public class ObavljeniPregledi : Controller
    {
        private _IDentalCheckWorkersRepository _dentalCheckWorkersRepository;
        private IDentalCheckRepository _dentalCheckRepository;
        private IAppointmentRepository _appointmentRepository;
        private IEstablishedDiagnosisRepository _eDiagnosisRepository;
        private IDiagnoseRepository _diagnoseRepository;
        private _IDentalCheckServicesRepository _dentalCheckServicesRepository;
        private IServiceRepository _serviceRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ObavljeniPregledi(_IDentalCheckWorkersRepository _dentalCheckWorkersRepository,
                                                UserManager<ApplicationUser> userManager,
                                                IAppointmentRepository _appointmentRepository,
                                                IEstablishedDiagnosisRepository _eDiagnosisRepository,
                                                IDentalCheckRepository _dentalCheckRepository,
                                                IDiagnoseRepository _diagnoseRepository,
                                                _IDentalCheckServicesRepository _dentalCheckServicesRepository,
                                                IServiceRepository _serviceRepository)
        {
            this._dentalCheckWorkersRepository = _dentalCheckWorkersRepository;
            this.userManager = userManager;
            this._appointmentRepository = _appointmentRepository;
            this._eDiagnosisRepository = _eDiagnosisRepository;
            this._dentalCheckRepository = _dentalCheckRepository;
            this._diagnoseRepository = _diagnoseRepository;
            this._dentalCheckServicesRepository = _dentalCheckServicesRepository;
            this._serviceRepository = _serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PrikaziUspostavljeneDijagnozeViewModel> modelList = new List<PrikaziUspostavljeneDijagnozeViewModel>();

            var doktor = await userManager.GetUserAsync(User);
            var pregledi = _dentalCheckWorkersRepository.GetDentalChecsAndkWorkers().ToList();
            List<DentalCheckUp> obavljeni_pregledi = new List<DentalCheckUp>();
            for(int i = 0; i < pregledi.Count(); i++)
            {
                if (pregledi[i].IdList.Contains(doktor.Id))
                    obavljeni_pregledi.Add(_dentalCheckRepository.GetDentalCheckUp(pregledi[i].DentalCheckUpId));

            }
            if (obavljeni_pregledi.Count() == 0)
                return View(modelList);

            var uspostavljeneDijagnoze = _eDiagnosisRepository.GetEDiagnosis().ToList();
            List<EstablishedDiagnosis> listaUpostavljenihDijagnoza = new List<EstablishedDiagnosis>();
            for(int i = 0; i < obavljeni_pregledi.Count(); i++)
            {

                for(int j = 0; j < uspostavljeneDijagnoze.Count(); j++)
                {
                    if (obavljeni_pregledi[i].Id == uspostavljeneDijagnoze[j].DentalCheckUpId)
                        listaUpostavljenihDijagnoza.Add(uspostavljeneDijagnoze[j]);
                }
            }

            if (listaUpostavljenihDijagnoza.Count() == 0)
                return View(modelList);


            List<Appointment> ListaTermina = new List<Appointment>();
            for(int i = 0; i < obavljeni_pregledi.Count(); i++)
            {
                ListaTermina.Add(_appointmentRepository.GetAppointment(obavljeni_pregledi[i].AppointmentId));
            }

            
           

            for(int i = 0; i < obavljeni_pregledi.Count(); i++)
            {
                List<Service> ListaUsluga = new List<Service>();
                PrikaziUspostavljeneDijagnozeViewModel model = new PrikaziUspostavljeneDijagnozeViewModel();
                model.Napomena = obavljeni_pregledi[i].Description;
                for(int j = 0; j < ListaTermina.Count(); j++)
                {
                    if (obavljeni_pregledi[i].AppointmentId == ListaTermina[j].Id)
                    {
                        model.Pacijent = await userManager.FindByIdAsync(ListaTermina[j].PatientId);
                        model.Datum = ListaTermina[j].Time;
                    }
                }

                for(int j = 0; j < listaUpostavljenihDijagnoza.Count(); j++)
                {
                    if (obavljeni_pregledi[i].Id == listaUpostavljenihDijagnoza[j].DentalCheckUpId)
                    {
                       
                        var dijagnoza = _diagnoseRepository.GetDiagnose(listaUpostavljenihDijagnoza[j].DiagnoseId);
                        model.Dijagnoza = dijagnoza.Name;
                    }
                }
                var uslugePregleda = _dentalCheckServicesRepository.GetDentalCheckServices(obavljeni_pregledi[i].Id);
                for(int j = 0; j < uslugePregleda.Services.Count(); j++)
                {
                    ListaUsluga.Add(_serviceRepository.GetService(uslugePregleda.Services[j]));
                }
                model.Usluge = ListaUsluga;
                modelList.Add(model);
            }
            modelList.Sort((x, y) => DateTime.Compare(y.Datum, x.Datum));
            return View(modelList);
        }
    }
}