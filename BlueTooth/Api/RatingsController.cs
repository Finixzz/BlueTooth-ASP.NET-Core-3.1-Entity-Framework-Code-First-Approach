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
    public class RatingsController : ControllerBase
    {
        private IRatingRepository _ratingRepository;
        private IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingsController(IRatingRepository ratingRepo,
                                      SignInManager<ApplicationUser> signInManager,
                                      UserManager<ApplicationUser> userManager,
                                      IMapper mapper)
        {
            _ratingRepository = ratingRepo;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetRating(int id)
        {
            // if (!_signInManager.IsSignedIn(User))


            Rating ratingInDb = _ratingRepository.GetRating(id);

            if (ratingInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Rating, RatingDto>(ratingInDb));
        }

        [HttpGet]
        public IActionResult GetRatings()
        {
            // if (!_signInManager.IsSignedIn(User))


            var appointmentDtos = _ratingRepository.GetRatings().Select(_mapper.Map<Rating, RatingDto>);
            return Ok(appointmentDtos);
        }


        [HttpPost]
        public IActionResult CreateAppointment(RatingDto ratingDto)
        {
            if (!_signInManager.IsSignedIn(User))
                return NotFound();


            ratingDto.UserId = _userManager.GetUserId(User);
            ModelState.Remove("ratingDto.Id");
            if (!ModelState.IsValid)
                return BadRequest();

            Rating newRating = _ratingRepository.AddRating(_mapper.Map<RatingDto, Rating>(ratingDto));

            ratingDto.Id = newRating.Id;

            return CreatedAtAction(nameof(ratingDto), new { id = ratingDto.Id }, ratingDto);
        }


 

        [HttpDelete("{id}")]
        public ActionResult<AppointmentDto> DeleteAppointment(int id)
        {
            Rating ratingInDb = _ratingRepository.GetRating(id);
            if (ratingInDb == null)
                return NotFound();

            return Ok(_mapper.Map<Rating, RatingDto>(_ratingRepository.DeleteRating(id)));
        }
    }
}