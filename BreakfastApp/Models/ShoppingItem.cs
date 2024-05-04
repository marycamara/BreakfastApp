using SQLite;

namespace BreakfastApp.Models
{
    public class ShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }
    }
}
