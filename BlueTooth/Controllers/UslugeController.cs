using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    [Authorize(Roles ="Vlasnik")]
    public class UslugeController : Controller
    {
        private IServiceRepository _servicesRepository;
        public UslugeController(IServiceRepository serviceRepo)
        {
            _servicesRepository = serviceRepo;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditUsluga(int uslugaId)
        {
            return View();
        }

        
    }
}