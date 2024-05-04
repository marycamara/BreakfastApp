using System;
using System.Collections.Generic;

namespace BreakfastApp.Models
{
    public class BreakfastList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri Image { get; set; }

        public List<string> Ingredients { get; set; }

        public List<string> AddOn { get; set; }

        public List<string> Nutrition { get; set; } // Updated property for nutrition information
    }
}
