using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BornToMove.DAL
{
    [Table(name:"move")]
    public class Move
    {
        public int Id { get; set; } = 0;            
        [Display(Name="Naam")]
        public string Name { get; set; } = "";
        [Display(Name="Omschrijving")]
        public string Description { get; set; } = "";
        virtual public ICollection<MoveRating>? Ratings { get; set; } = new List<MoveRating>();
    }     
}  
   