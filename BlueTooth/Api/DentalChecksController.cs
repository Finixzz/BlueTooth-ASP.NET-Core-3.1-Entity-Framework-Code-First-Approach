using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class DentalChecksController : ControllerBase
    {
        private IDentalCheckRepository _dentalChecksRepository;
        private IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DentalChecksController(IDentalCheckRepository dentalChecksRepository,
                                      IMapper mapper,
                                      SignInManager<ApplicationUser> signInManager)
        {
            _dentalChecksRepository = dentalChecksRepository;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        //GET /api/dentalchecks
        [HttpGet]
        public ActionResult<DentalCheckUpDto> GetDentalCheckUps()
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            var dentalCheckDtos = _dentalChecksRepository.GetDentalChecks().Select(_mapper.Map<DentalCheckUp, DentalCheckUpDto>);
            return Ok(dentalCheckDtos);
        }

        //GET /api/dentalchecks/1
        [HttpGet("{id}")]
        public ActionResult<DentalCheckUpDto> GetDentalCheckUp(int id)
        {
           // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            var dentalCheckUpInDb = _dentalChecksRepository.GetDentalCheckUp(id);
            if (dentalCheckUpInDb == null)
                return NotFound();

            return Ok(_mapper.Map<DentalCheckUp, DentalCheckUpDto>(dentalCheckUpInDb));
        }

        //POST /api/dentalchecks
        [HttpPost]
        public ActionResult<DentalCheckUpDto> CreateDentalCheckUp(DentalCheckUpDto dentalCheckUpDto)
        {
            //if (!_signInManager.IsSignedIn(User))
             //   return RedirectToAction("NotFound", "Error");

            ModelState.Remove("dentalCheckUpDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            DentalCheckUp newDentalCheckUp = _dentalChecksRepository.CreateDentalCheckUp(_mapper.Map<DentalCheckUpDto, DentalCheckUp>(dentalCheckUpDto));

            dentalCheckUpDto.Id = newDentalCheckUp.Id;

            return CreatedAtAction(nameof(dentalCheckUpDto), new { id = dentalCheckUpDto.Id }, dentalCheckUpDto);
        }

        //POST /api/dentalchecks/1
        [HttpPut("{id}")]
        public ActionResult<AppointmentDto> EditDentalCheckUp(DentalCheckUpDto dentalCheckUpDto, int id)
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            ModelState.Remove("dentalCheckUpDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            DentalCheckUp dentalCheckUpInDb = _dentalChecksRepository.GetDentalCheckUp(id);
            if (dentalCheckUpInDb == null)
                return NotFound();

            _mapper.Map(dentalCheckUpDto, dentalCheckUpInDb);
            return Ok(_mapper.Map<DentalCheckUp, DentalCheckUpDto>(_dentalChecksRepository.EditDentalCheckUp(dentalCheckUpInDb, id)));
        }

        //POST /api/dentalchecks/1
        [HttpDelete("{id}")]
        public ActionResult<DentalCheckUpDto> DeleteDentalCheckUp(int id)
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            DentalCheckUp dentalCheckUpDtoInDb = _dentalChecksRepository.GetDentalCheckUp(id);
            if (dentalCheckUpDtoInDb == null)
                return NotFound();

            return Ok(_mapper.Map<DentalCheckUp, DentalCheckUpDto>(_dentalChecksRepository.DeleteDentalCheckUp(id)));
        }
    }
}