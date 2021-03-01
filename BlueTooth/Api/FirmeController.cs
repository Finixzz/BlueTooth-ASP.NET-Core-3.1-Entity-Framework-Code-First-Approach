using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlueTooth.Dtos;
using BlueTooth.Models;
using BlueTooth.Models.Implementations;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmeController : ControllerBase
    {
        private IFirmaRepository _firmaRepository;
        private IMapper _mapper;

        public FirmeController(IFirmaRepository firmaRepo, IMapper mapper)
        {
            _firmaRepository = firmaRepo;
            _mapper = mapper;
        }


        //GET /api/firme
        [HttpGet]
        public ActionResult<FirmaDto> GetFirme()
        {
            var firmeDtos = _firmaRepository.GetFirme().Select(_mapper.Map<Firma, FirmaDto>);
            return Ok(firmeDtos);
        }

        //GET /api/firme/1
        [HttpGet("{id}")]
        public ActionResult<FirmaDto> GetFirma(int id)
        {
            Firma firmaInDb = _firmaRepository.GetFirma(id);
            if (firmaInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Firma, FirmaDto>(firmaInDb));
        }

        //POST /api/firme
        [HttpPost]
        public ActionResult<FirmaDto> CreateFirma(FirmaDto firmaDto)
        {
            ModelState.Remove("firmaDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Firma newFirmaInDb = _firmaRepository.CreateFirma(_mapper.Map<FirmaDto, Firma>(firmaDto));

            firmaDto.Id = newFirmaInDb.Id;

            return CreatedAtAction(nameof(firmaDto), new { id = firmaDto.Id }, firmaDto);
        }

        //PUT /api/firme/1
        [HttpPut("{id}")]
        public ActionResult<FirmaDto> EditFirma(FirmaDto firmaDto,int id)
        {
            ModelState.Remove("firmaDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Firma firmaInDb = _firmaRepository.GetFirma(id);
            if (firmaInDb == null)
                return NotFound();

            _mapper.Map(firmaDto, firmaInDb);
            return Ok(_mapper.Map<Firma,FirmaDto>(_firmaRepository.EditFirma(firmaInDb, id)));
        }

        //DELETE /api/firme/1
        [HttpDelete("{id}")]
        public ActionResult<FirmaDto> DeleteFirma(int id)
        {
            Firma firmaInDb = _firmaRepository.GetFirma(id);
            if (firmaInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Firma, FirmaDto>(_firmaRepository.DeleteFirma(id)));
        }

    }
}