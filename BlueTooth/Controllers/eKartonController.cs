using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    [Authorize(Roles ="Pacijent,Vlasnik,Radnik,ARadnik")]
    public class eKartonController : Controller
    {
        private _IDentalCheckWorkersRepository _dentalCheckWorkersRepository;
        private IDentalCheckRepository _dentalCheckRepository;
        private IAppointmentRepository _appointmentRepository;
        private IEstablishedDiagnosisRepository _eDiagnosisRepository;
        private IDiagnoseRepository _diagnoseRepository;
        private _IDentalCheckServicesRepository _dentalCheckServicesRepository;
        private IServiceRepository _serviceRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public eKartonController(_IDentalCheckWorkersRepository _dentalCheckWorkersRepository,
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
            List<PrikaziUspostavljeneDijagnozePacijentaViewModel> modelList = new List<PrikaziUspostavljeneDijagnozePacijentaViewModel>();

            var pacijent = await userManager.GetUserAsync(User);

            var termini = _appointmentRepository.GetAppointments().ToList();
            List<Appointment> ListaTermina = new List<Appointment>();
            for (int i = 0; i < termini.Count(); i++)
            {
                if (termini[i].PatientId == pacijent.Id)
                    ListaTermina.Add(termini[i]);
            }


            var pregledi = _dentalCheckRepository.GetDentalChecks().ToList();
            List<DentalCheckUp> obavljeniPregledi = new List<DentalCheckUp>();
            for(int i = 0; i < pregledi.Count(); i++)
            {
                if (ListaTermina.Contains(pregledi[i].Appointment))
                    obavljeniPregledi.Add(pregledi[i]);
            }

            

            var uspostavljeneDijagnoze = _eDiagnosisRepository.GetEDiagnosis().ToList();
            List<EstablishedDiagnosis> listaUpostavljenihDijagnoza = new List<EstablishedDiagnosis>();
            for (int i = 0; i < obavljeniPregledi.Count(); i++)
            {

                for (int j = 0; j < uspostavljeneDijagnoze.Count(); j++)
                {
                    if (obavljeniPregledi[i].Id == uspostavljeneDijagnoze[j].DentalCheckUpId)
                        listaUpostavljenihDijagnoza.Add(uspostavljeneDijagnoze[j]);
                }
            }






            for (int i = 0; i < obavljeniPregledi.Count(); i++)
            {
                List<Service> ListaUsluga = new List<Service>();
                PrikaziUspostavljeneDijagnozePacijentaViewModel model = new PrikaziUspostavljeneDijagnozePacijentaViewModel();
                model.Napomena = obavljeniPregledi[i].Description;
                model.Datum = ListaTermina[i].Time;

                var preglediDoktori = _dentalCheckWorkersRepository.GetDentalChecsAndkWorkers().ToList();

                for(int j = 0; j < preglediDoktori.Count(); j++)
                {
                    if (obavljeniPregledi[i].Id == preglediDoktori[j].DentalCheckUpId)
                        for (int k = 0; k < preglediDoktori[j].IdList.Count(); k++)
                            model.Doktori.Add(await userManager.FindByIdAsync(preglediDoktori[j].IdList[k]));
                }



                for (int j = 0; j < listaUpostavljenihDijagnoza.Count(); j++)
                {
                    if (obavljeniPregledi[i].Id == listaUpostavljenihDijagnoza[j].DentalCheckUpId)
                    {

                        var dijagnoza = _diagnoseRepository.GetDiagnose(listaUpostavljenihDijagnoza[j].DiagnoseId);
                        model.Dijagnoza = dijagnoza.Name;
                    }
                }

                var uslugePregleda = _dentalCheckServicesRepository.GetDentalCheckServices(obavljeniPregledi[i].Id);
                for (int j = 0; j < uslugePregleda.Services.Count(); j++)
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