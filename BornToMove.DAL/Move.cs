using System;
using System.Collections.Generic;

namespace BornToMove.DAL
{
    public class Move
    {
        public int Id { get; set; } = 0;            //Dit kan een foutmelding geven, dan even checken
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int SweatRate { get; set; } = 0;

       //public List<Ratings> Ratings { get; set; }

       public Move(string name, string description, int sweatRate)
       {
            Name = name;
            Description = description;
            SweatRate = sweatRate;
       }
    }
}
