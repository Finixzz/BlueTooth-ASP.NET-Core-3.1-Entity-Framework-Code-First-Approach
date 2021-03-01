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
    public class eDiagnosisController : ControllerBase
    {
        private IEstablishedDiagnosisRepository _establishedDiagnosisRepository;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public eDiagnosisController(IEstablishedDiagnosisRepository establishedDiagnosisRepository,
                                              IMapper mapper,
                                              UserManager<ApplicationUser> userManager)
        {
            _establishedDiagnosisRepository = establishedDiagnosisRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        //GET /api/ediagnosis
        [HttpGet]
        public ActionResult<EstablishedDiagnosisDto> GetEDiagnosis()
        {
            // if(!_signInManager.IsSignedIn(User))
            //     return RedirectToAction("NotFound", "Error");
            var eDiagnoseDtos = _establishedDiagnosisRepository.GetEDiagnosis().Select(_mapper.Map<EstablishedDiagnosis, EstablishedDiagnosisDto>);
            return Ok(eDiagnoseDtos);
        }

        //GET /api/ediagnosis/1
        [HttpGet("{id}")]
        public ActionResult<EstablishedDiagnosisDto> GetEDiagnose(int id)
        {
            // if(!_signInManager.IsSignedIn(User))
            //     return RedirectToAction("NotFound", "Error");

            EstablishedDiagnosis eDiagnoseInDb = _establishedDiagnosisRepository.GetEDiagnose(id);
            if (eDiagnoseInDb == null)
                return NotFound();

            return Ok(_mapper.Map<EstablishedDiagnosis, EstablishedDiagnosisDto>(eDiagnoseInDb));
        }


        //Post /api/ediagnosis
        [HttpPost]
        public ActionResult<EstablishedDiagnosisDto> AddEDiagnose(EstablishedDiagnosisDto eDiagnoseDto)
        {
            ModelState.Remove("eDiagnose.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            EstablishedDiagnosis newEDiagnose = _establishedDiagnosisRepository.AddEDiagnose(_mapper.Map<EstablishedDiagnosisDto, EstablishedDiagnosis>(eDiagnoseDto));

            eDiagnoseDto.Id = newEDiagnose.Id;

            return CreatedAtAction(nameof(eDiagnoseDto), new { id=eDiagnoseDto.Id }, eDiagnoseDto);
        }

        //Put /api/ediagnosis/1
        [HttpPut("{id}")]
        public ActionResult<EstablishedDiagnosisDto> EditEDiagnose(EstablishedDiagnosisDto eDiagnoseDto, int id)
        {
            EstablishedDiagnosis eDiagnoseInDb = _establishedDiagnosisRepository.GetEDiagnose(id);
            if (eDiagnoseInDb == null)
                return NotFound();

            ModelState.Remove("eDiagnose.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            _mapper.Map(eDiagnoseDto, eDiagnoseInDb);
            return Ok(_mapper.Map<EstablishedDiagnosis,EstablishedDiagnosis>(_establishedDiagnosisRepository.EditEDiagnose(eDiagnoseInDb,id)));
        }

        //Delete /api/ediagnosis/1
        [HttpDelete("{id}")]
        public ActionResult<EstablishedDiagnosisDto> DeleteEDiagnose(int id)
        {
            EstablishedDiagnosis eDiagnoseInDb = _establishedDiagnosisRepository.GetEDiagnose(id);
            if (eDiagnoseInDb == null)
                return NotFound();

            return Ok(_mapper.Map<EstablishedDiagnosis,EstablishedDiagnosisDto>(_establishedDiagnosisRepository.DeleteEDiagnose(id)));
        }
    }
}