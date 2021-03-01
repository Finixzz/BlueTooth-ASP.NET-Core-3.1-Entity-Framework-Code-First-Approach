using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlueTooth.Dtos;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IAppointmentRepository _appointmentRepository;
        private IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentsController(IAppointmentRepository appointmentRepo,
                                      SignInManager<ApplicationUser> signInManager,
                                      UserManager<ApplicationUser> userManager,
                                      IMapper mapper)
        {
            _appointmentRepository = appointmentRepo;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
           // if (!_signInManager.IsSignedIn(User))
         

            Appointment appointmentInDb = _appointmentRepository.GetAppointment(id);

            if (appointmentInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Appointment, AppointmentDto>(appointmentInDb));
        }

        [HttpGet]
        public IActionResult GetAppointments()
        {
           // if (!_signInManager.IsSignedIn(User))
        

            var appointmentDtos = _appointmentRepository.GetAppointments().Select(_mapper.Map<Appointment, AppointmentDto>);
            return Ok(appointmentDtos);
        }
        

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentDto appointmentDto)
        {
           // if (!_signInManager.IsSignedIn(User))
                

            appointmentDto.PatientId= _userManager.GetUserId(User);
            ModelState.Remove("appointmentDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Appointment newAppointment = _appointmentRepository.CreateAppointment(_mapper.Map<AppointmentDto, Appointment>(appointmentDto));

            appointmentDto.Id = newAppointment.Id;

            return CreatedAtAction(nameof(appointmentDto), new { id = appointmentDto.Id }, appointmentDto);
        }

       
        [HttpPut("{id}")]
        public ActionResult<AppointmentDto> EditAppointment(AppointmentDto appointmentDto, int id)
        {
            ModelState.Remove("firmaDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Appointment appointmentInDb = _appointmentRepository.GetAppointment(id);
            if (appointmentInDb == null)
                return NotFound();

            _mapper.Map(appointmentDto, appointmentInDb);
            return Ok(_mapper.Map<Appointment, AppointmentDto>(_appointmentRepository.EditAppointment(appointmentInDb, id)));
        }

        [HttpDelete("{id}")]
        public ActionResult<AppointmentDto> DeleteAppointment(int id)
        {
            Appointment appointmentInDb = _appointmentRepository.GetAppointment(id);
            if (appointmentInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Appointment, AppointmentDto>(_appointmentRepository.DeleteAppointment(id)));
        }
    }
}