using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Dtos;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetPacijentPreglediController : ControllerBase
    {
        private IAppointmentRepository _appointmentRepository;
        private UserManager<ApplicationUser> userManager;

        public GetPacijentPreglediController(IAppointmentRepository _appointmentRepository,
                                              UserManager<ApplicationUser> userManager)
        {
            this._appointmentRepository = _appointmentRepository;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetAllPatientAppointments(string id)
        {
            var patient = await userManager.FindByIdAsync(id);
            var appointments = _appointmentRepository.GetAppointments().ToList();
            PatientDentalChecks pdcs = new PatientDentalChecks()
            {
                Pacijent = patient
            };
            for(int i = 0; i < appointments.Count(); i++)
            {
                if (appointments[i].PatientId == pdcs.Pacijent.Id)
                    pdcs.AppointmentList.Add(appointments[i].Id);
            }

            return Ok(pdcs);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("[1,3,4]");
        }
    }
}