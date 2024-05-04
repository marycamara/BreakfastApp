using System.Collections.Generic;
using SQLite;

namespace BreakfastApp.Models
{
    [Table(nameof(BreakfastList))]
    public class BreakfastTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUri { get; set; }

        public string Ingredients { get; set; }

        public string AddOn { get; set; }

        public string Nutrition { get; set; } // Nutrition will be initialized as an empty JSON array when not provided
    }
}
