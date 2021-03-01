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
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private IBillRepository _billRepository;
        private IMapper _mapper;

        public BillsController(IBillRepository _billRepository,
                               IMapper _mapper)
        {
            this._billRepository = _billRepository;
            this._mapper = _mapper;
        }


        [HttpGet]
        public IActionResult GetAllBills()
        {
            return Ok(_billRepository.GetBills().Select(_mapper.Map<Bill,BillDto>));
        }

        [HttpGet("{id}")]
        public IActionResult GetBill(int id)
        {
            return Ok(_mapper.Map<Bill,BillDto>(_billRepository.GetBill(id)));
        }

        [HttpPost]
        public IActionResult AddBill(BillDto bill)
        {
            bill.Time = DateTime.Now;
            Bill newBill = _billRepository.AddBill(_mapper.Map<BillDto,Bill>(bill));
            bill.Id = newBill.Id;
            return CreatedAtAction(nameof(newBill), newBill.Id, newBill);
        }
    }
}