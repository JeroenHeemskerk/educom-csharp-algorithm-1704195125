using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BornToMove.DAL
{
    [Table(name:"rating")]
    public class MoveRating
    {
        public int Id { get; set; } = 0;            
        public Move? Move { get; set; }
        [Display(Name ="Intensiteit")]
        public double Rating { get; set; }
        public double Vote { get; set; }
    
        public MoveRating(Move move, int rating, int vote)
        {
            Move = move;
            Rating = rating;
            Vote = vote;

        } 

        public MoveRating ()
        {
            
        }
    }     

}