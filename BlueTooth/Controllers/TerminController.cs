using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.DbContext;
using BlueTooth.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    public class TerminController : Controller
    {
        private ApplicationDbContext _context;

        public TerminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var appointments = _context.Appointments.ToList();

            return View(appointments);
        }

        
    }
}