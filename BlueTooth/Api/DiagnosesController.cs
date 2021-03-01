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
    public class DiagnosesController : ControllerBase
    {
        private IDiagnoseRepository _diagnosesRepository;
        private IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DiagnosesController(IDiagnoseRepository diagnosesRepository,
                                      IMapper mapper,
                                      SignInManager<ApplicationUser> signInManager)
        {
            _diagnosesRepository = diagnosesRepository;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        //GET /api/diagnoses
        [HttpGet]
        public ActionResult<DiagnoseDto> GetDiagnoses()
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            var diagnoseDtos = _diagnosesRepository.GetDiagnoses().Select(_mapper.Map<Diagnose, DiagnoseDto>);
            return Ok(diagnoseDtos);
        }

        //GET /api/diagnoses/1
        [HttpGet("{id}")]
        public ActionResult<DiagnoseDto> GetDiagnose(int id)
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            var diagnoseInDb = _diagnosesRepository.GetDiagnose(id);
            if (diagnoseInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Diagnose, DiagnoseDto>(diagnoseInDb));
        }

        //POST /api/diagnoses
        [HttpPost]
        public ActionResult<DiagnoseDto> AddDiagnose(DiagnoseDto diagnoseDto)
        {
            //if (!_signInManager.IsSignedIn(User))
            //   return RedirectToAction("NotFound", "Error");

            ModelState.Remove("diagnoseDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Diagnose newDiagnose = _diagnosesRepository.AddDiagnose(_mapper.Map<DiagnoseDto, Diagnose>(diagnoseDto));

            diagnoseDto.Id = newDiagnose.Id;

            return CreatedAtAction(nameof(diagnoseDto), new { id = diagnoseDto.Id }, diagnoseDto);
        }


        //POST /api/diagnoses/1
        [HttpPut("{id}")]
        public ActionResult<DiagnoseDto> EditDiagnose(DiagnoseDto diagnoseDto, int id)
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            ModelState.Remove("dentalCheckUpDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Diagnose diagnoseInDb = _diagnosesRepository.GetDiagnose(id);
            if (diagnoseInDb == null)
                return NotFound();

            _mapper.Map(diagnoseDto, diagnoseInDb);
            return Ok(_mapper.Map<Diagnose, DiagnoseDto>(_diagnosesRepository.EditDiagnose(diagnoseInDb, id)));
        }

        //POST /api/diagnoses/1
        [HttpDelete("{id}")]
        public ActionResult<DiagnoseDto> DeleteDiagnose(int id)
        {
            // if (!_signInManager.IsSignedIn(User))
            //    return RedirectToAction("NotFound", "Error");

            Diagnose diagnoseInDb = _diagnosesRepository.GetDiagnose(id);
            if (diagnoseInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Diagnose, DiagnoseDto>(_diagnosesRepository.DeleteDiagnose(id)));
        }
    }
}