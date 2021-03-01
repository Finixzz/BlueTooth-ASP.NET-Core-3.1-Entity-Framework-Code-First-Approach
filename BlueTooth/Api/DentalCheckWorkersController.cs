using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlueTooth.Dtos;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentalCheckWorkersController : ControllerBase
    {
        private _IDentalCheckWorkersRepository _dentalCheckWorkersRepository;
        private IMapper _mapper;

        public DentalCheckWorkersController(_IDentalCheckWorkersRepository dentalCheckWorkersRepository,
                                            IMapper mapper)
        {
            _dentalCheckWorkersRepository = dentalCheckWorkersRepository;
            _mapper = mapper;
        }

        //get /api/dentalcheckworkers
        [HttpGet]
        public ActionResult<_DentalCheckWorkersDto> GetDentalChecksAndWorkers()
        {
            var dentalChecksAndWorkersDto = _dentalCheckWorkersRepository
                                                    .GetDentalChecsAndkWorkers()
                                                    .Select(_mapper.Map<_DentalCheckWorkers, _DentalCheckWorkersDto>);
            return Ok(dentalChecksAndWorkersDto);
        }

        //get /api/dentalcheckworkers/1
        [HttpGet("{id}")]
        public ActionResult<_DentalCheckWorkersDto> GetDentalCheckWorkers(int id)
        {
            if (!_dentalCheckWorkersRepository.ExistsInDb(id))
                return NotFound();

            _DentalCheckWorkers dentalCheckWorkersInDb = _dentalCheckWorkersRepository.GetDentalCheckWorkers(id);

            if (dentalCheckWorkersInDb == null)
                return NotFound();

            return Ok(_mapper.Map<_DentalCheckWorkers, _DentalCheckWorkersDto>(dentalCheckWorkersInDb));
        }

        //get /api/dentalcheckworkers
        [HttpPost]
        public ActionResult<_DentalCheckWorkersDto> AddDentalCheckWorkers(_DentalCheckWorkersDto dentalCheckWorkersDto)
        {
            if (!_dentalCheckWorkersRepository.HasWorkerAssigned(dentalCheckWorkersDto.IdList.Count()))
                return BadRequest();

            for(int i = 0; i < dentalCheckWorkersDto.IdList.Count(); i++)
            {
                if (!ModelState.IsValid)
                    return BadRequest();     
            }

            _DentalCheckWorkers newDentalCheckWorkers = _dentalCheckWorkersRepository.AddDentalCheckWorkers(_mapper.Map<_DentalCheckWorkersDto, _DentalCheckWorkers>(dentalCheckWorkersDto));
            _mapper.Map(newDentalCheckWorkers, dentalCheckWorkersDto);
            return CreatedAtAction(nameof(dentalCheckWorkersDto), new { id = dentalCheckWorkersDto.DentalCheckUpId }, dentalCheckWorkersDto);
        }

        //put /api/dentalcheckworkers/1
        [HttpPut("{id}")]
        public ActionResult<_DentalCheckWorkersDto> EditDentalCheckWorkers(_DentalCheckWorkersDto dentalCheckWorkersDto,int id)
        {
            if (!_dentalCheckWorkersRepository.ExistsInDb(id))
                return NotFound();

            _DentalCheckWorkers dentalCheckWorkersInDb = _dentalCheckWorkersRepository.GetDentalCheckWorkers(id);

            _mapper.Map(dentalCheckWorkersDto, dentalCheckWorkersInDb);
            return Ok(_mapper.Map<_DentalCheckWorkers, _DentalCheckWorkersDto>(_dentalCheckWorkersRepository.EditDentalCheckWorkers(dentalCheckWorkersInDb,id)));

        }

        //delete /api/dentalcheckworkers/1
        [HttpDelete("{id}")]
        public ActionResult<_DentalCheckWorkersDto> DeleteDentalCheckWorkers(int id)
        {
            _DentalCheckWorkers dentalCheckWorkersDtoInDb = _dentalCheckWorkersRepository.GetDentalCheckWorkers(id);

            if (!_dentalCheckWorkersRepository.ExistsInDb(id) && 
                !_dentalCheckWorkersRepository.HasWorkerAssigned(dentalCheckWorkersDtoInDb.IdList.Count()))
                return NotFound();

            return Ok(_mapper.Map<_DentalCheckWorkers,_DentalCheckWorkersDto>(_dentalCheckWorkersRepository.DeleteDentalCheckWorkers(id)));
        }
    }
}