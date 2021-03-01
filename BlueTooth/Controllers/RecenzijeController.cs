using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlueTooth.Dtos;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Controllers
{
    [Authorize]
    public class RecenzijeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private IRatingRepository _ratingeRepository;
        private IMapper _mapper;

        public RecenzijeController(UserManager<ApplicationUser> userManager,
                                    IRatingRepository ratingRepository,
                                    IMapper mapper)
        {
            this.userManager = userManager;
            _ratingeRepository = ratingRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Rating rating = new Rating();
            return View(rating);
        }

        [Authorize(Roles ="Vlasnik,Admin")]
        [HttpGet]
        public IActionResult Prikaz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SpremiRecenziju(RatingDto ratingDto)
        {
            ratingDto.UserId = userManager.GetUserId(User);

            _ratingeRepository.AddRating(_mapper.Map<RatingDto, Rating>(ratingDto));

            return View("Feedback");
        }
    }
}