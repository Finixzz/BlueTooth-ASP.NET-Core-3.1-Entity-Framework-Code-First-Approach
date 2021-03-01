using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IRatingRepository
    {
        Rating GetRating(int id);
        IEnumerable<Rating> GetRatings();
        Rating AddRating(Rating rating);
        Rating DeleteRating(int id);
    
    }
}
