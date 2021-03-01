using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCSController : ControllerBase
    {
        private _IDentalCheckServicesRepository _dentalCheckServicesRepository;

        public DCSController(_IDentalCheckServicesRepository _dentalCheckServicesRepository)
        {
            this._dentalCheckServicesRepository = _dentalCheckServicesRepository;
        }

        //POST /api/dcs
        [HttpGet]
        public IActionResult GetDCSS()
        {
            return Ok(_dentalCheckServicesRepository.GetAllDentalCheckServices());
        }

        //POST /api/dcs/get
        [HttpGet("{id}")]
        public IActionResult GetDCS(int id)
        {
            return Ok(_dentalCheckServicesRepository.GetDentalCheckServices(id));
        }


        //POST /api/dcs
        [HttpPost]
        public IActionResult AddDCS(_DentalCheckServices dcs)
        {
            var newdcs = _dentalCheckServicesRepository.AddDentalCheckServices(dcs);
            return CreatedAtAction(nameof(newdcs), newdcs.DentalCheckID, newdcs);
        }

    }
}