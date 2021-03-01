using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class RatingSQLRepository : IRatingRepository
    {
        private ApplicationDbContext _context;

        public RatingSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Rating AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            return rating;
        }

        public Rating DeleteRating(int id)
        {
            Rating ratingInDb = _context.Ratings.SingleOrDefault(c => c.Id == id);
            _context.Ratings.Remove(ratingInDb);
            _context.SaveChanges();
            return ratingInDb;
        }

        public Rating GetRating(int id)
        {
            return _context.Ratings.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Rating> GetRatings()
        {
            return _context.Ratings;
        }
    }
}
