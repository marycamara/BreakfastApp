using System.Collections.Generic;
using SQLite;
using System.Linq;
using BreakfastApp.Models; // Assuming ShoppingItem is defined in the BreakfastApp.Models namespace

namespace BreakfastApp.Services
{
    public class ShoppingListService
    {
        private readonly SQLiteConnection _database;

        public ShoppingListService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<ShoppingItem>(); // Create the ShoppingItem table if it doesn't exist
        }

        public List<ShoppingItem> GetShoppingItems()
        {
            return _database.Table<ShoppingItem>().ToList();
        }

        public void AddShoppingItem(ShoppingItem item)
        {
            _database.Insert(item);
        }

        // Add other CRUD operations as needed
    }
}
