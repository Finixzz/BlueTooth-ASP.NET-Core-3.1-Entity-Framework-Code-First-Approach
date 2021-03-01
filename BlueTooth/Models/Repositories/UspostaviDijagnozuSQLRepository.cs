using BlueTooth.Models.Interfaces;
using BlueTooth.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class UspostaviDijagnozuRepository : IUspostaviDijagnozu
    {
        private readonly UserManager<ApplicationUser> userManager;
        private IAppointmentRepository _appointmentRepository;
        private IDentalCheckRepository _dentalCheckRepository;
        private IEstablishedDiagnosisRepository _establishedDiagnosisRepository;
        private _IDentalCheckServicesRepository _dentalCheckServicesRepository;
        private _IDentalCheckWorkersRepository _dentalCheckWorkersRepository;
        public UspostaviDijagnozuRepository(UserManager<ApplicationUser> userManager,
                                            IAppointmentRepository _appointmentRepository,
                                            IDentalCheckRepository _dentalCheckRepository,
                                            IEstablishedDiagnosisRepository _establishedDiagnosisRepository,
                                            _IDentalCheckServicesRepository _dentalCheckServicesRepository,
                                            _IDentalCheckWorkersRepository _dentalCheckWorkersRepository)
        {
            this.userManager = userManager;
            this._appointmentRepository = _appointmentRepository;
            this._dentalCheckRepository = _dentalCheckRepository;
            this._establishedDiagnosisRepository = _establishedDiagnosisRepository;
            this._dentalCheckServicesRepository = _dentalCheckServicesRepository;
            this._dentalCheckWorkersRepository = _dentalCheckWorkersRepository;
        }


        public UspostaviDijagnozuModel UspostaviDijagnozu(UspostaviDijagnozuModel model)
        {
            Appointment newAppointment = new Appointment()
            {
                PatientId = model.PacijentId,
                Time = DateTime.Now,
                IsValid = true
            };
            newAppointment = _appointmentRepository.CreateAppointment(newAppointment);

            DentalCheckUp dentalCheckUp = new DentalCheckUp()
            {
                AppointmentId = newAppointment.Id,
                Description = model.Komentar

            };
            dentalCheckUp = _dentalCheckRepository.CreateDentalCheckUp(dentalCheckUp);

            EstablishedDiagnosis eDiagnosis = new EstablishedDiagnosis()
            {
                DiagnoseId = model.DijagnozaId,
                DentalCheckUpId = dentalCheckUp.Id

            };
            eDiagnosis = _establishedDiagnosisRepository.AddEDiagnose(eDiagnosis);


            _DentalCheckWorkers dentalCheckWorkers = new _DentalCheckWorkers()
            {
                DentalCheckUpId = dentalCheckUp.Id
            };
            dentalCheckWorkers.IdList.Add(model.DoktorId);
            dentalCheckWorkers = _dentalCheckWorkersRepository.AddDentalCheckWorkers(dentalCheckWorkers);


            _DentalCheckServices dcs = new _DentalCheckServices
            {
                DentalCheckID = dentalCheckUp.Id,
                Services = model.Usluge
            };
            dcs = _dentalCheckServicesRepository.AddDentalCheckServices(dcs);
            return model;
        }
    }
}
