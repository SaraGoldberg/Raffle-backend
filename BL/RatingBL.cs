using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{
    public class RatingBL : IRatingBL
    {
        IRatingDL _ratingDL;
        public RatingBL(IRatingDL rating)
        {
            _ratingDL = rating;
        }
        public Task postRating(Rating value)
        {
            return _ratingDL.postRating(value);
        }
    }
}
