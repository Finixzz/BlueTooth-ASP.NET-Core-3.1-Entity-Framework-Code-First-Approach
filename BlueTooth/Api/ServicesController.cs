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
    public class ServicesController : ControllerBase
    {
        private IServiceRepository _serviceRepository;
        private IMapper _mapper;


        public ServicesController(IServiceRepository serviceRepo,
                                  IMapper mapper)
        {
            _serviceRepository = serviceRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            Service serviceInDb = _serviceRepository.GetService(id);

            if (serviceInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Service, ServiceDto>(serviceInDb));
        }

        [HttpGet]
        public IActionResult GetServices()
        {

            var serviceDtos = _serviceRepository.GetServices().Select(_mapper.Map<Service, ServiceDto>).ToList();
                   
            return Ok(serviceDtos);
        }


        [HttpPost]
        public IActionResult CreateService(ServiceDto serviceDto)
        {

            ModelState.Remove("serviceDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Service newService = _serviceRepository.AddService(_mapper.Map<ServiceDto, Service>(serviceDto));

            serviceDto.Id = newService.Id;

            return CreatedAtAction(nameof(serviceDto), new { id = serviceDto.Id }, serviceDto);
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceDto> EditService(ServiceDto serviceDto,int id)
        {
            Service serviceInDb = _serviceRepository.GetService(id);
            if (serviceInDb == null)
                return NotFound();

            _mapper.Map(serviceDto, serviceInDb);
            return Ok(_mapper.Map<Service,ServiceDto>(_serviceRepository.EditService(serviceInDb, id)));
        }


        [HttpDelete("{id}")]
        public ActionResult<ServiceDto> DeleteService(int id)
        {
            Service serviceInDb = _serviceRepository.GetService(id);
            if (serviceInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Service, ServiceDto>(_serviceRepository.DeleteService(id)));
        }
    }
}