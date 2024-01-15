using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BornToMove.DAL
{
    public class RatingsConverter : IComparer<MoveRating>
    {
        public int Compare(MoveRating moveRatingA, MoveRating moveRatingB)
        {
            return moveRatingB.Rating.CompareTo(moveRatingA.Rating);
        }  
    }
}