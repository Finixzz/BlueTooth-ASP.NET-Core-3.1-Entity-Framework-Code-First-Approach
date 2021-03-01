using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueTooth.Models;
using BlueTooth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlueTooth.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllRatingInfoController : ControllerBase
    {
        private IRatingRepository ratingRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public GetAllRatingInfoController(IRatingRepository ratingRepository,
                                          UserManager<ApplicationUser> userManager)
        {
            this.ratingRepository = ratingRepository;
            this.userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratingsInDb = ratingRepository.GetRatings().ToList();
            List<Rating> ratings = new List<Rating>();
            for(int i = 0; i < ratingsInDb.Count(); i++)
            {
                Rating rating = new Rating()
                {
                    Id = ratingsInDb[i].Id,
                    Mark = ratingsInDb[i].Mark,
                    Comment = ratingsInDb[i].Comment,
                    UserId = ratingsInDb[i].UserId,
                    User = await userManager.FindByIdAsync(ratingsInDb[i].UserId)

                };
                ratings.Add(rating);
            }
            return Ok(ratings);
        }
    }
}