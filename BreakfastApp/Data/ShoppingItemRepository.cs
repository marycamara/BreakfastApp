using System.Collections.ObjectModel;
using System.Linq;
using BreakfastApp.Models; // Add this line to import the ShoppingItem class

namespace BreakfastApp.Data
{
    public class ShoppingItemRepository
    {
        private ObservableCollection<ShoppingItem> shoppingItems;

        public ShoppingItemRepository()
        {
            // Initialize with sample data
            shoppingItems = new ObservableCollection<ShoppingItem>
            {
                new ShoppingItem { Name = "Apples" },
                new ShoppingItem { Name = "Milk" },
                new ShoppingItem { Name = "Bread" }
            };
        }

        public ObservableCollection<ShoppingItem> GetAllItems()
        {
            return shoppingItems;
        }

        public void AddItem(ShoppingItem item)
        {
            shoppingItems.Add(item);
        }
    }
}
