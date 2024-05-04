using BreakfastApp.Models;
using BreakfastApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BreakfastApp.ViewModels
{
    public class ShoppingListViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ShoppingListService shoppingListService;

        public ObservableCollection<ShoppingItem> ShoppingItems { get; private set; }
        public ICommand AddItemCommand { get; }

        private string itemName;
        public string ItemName
        {
            get => itemName;
            set
            {
                if (itemName != value)
                {
                    itemName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }

        public ShoppingListViewModel()
        {
            // Provide the database path when creating a new instance of ShoppingListService
            string dbPath = "your_database_path.db"; // Replace "your_database_path.db" with your actual database path
            shoppingListService = new ShoppingListService(dbPath);
            LoadShoppingItems();

            AddItemCommand = new Command(AddItem);
        }

        private void LoadShoppingItems()
        {
            var items = shoppingListService.GetShoppingItems();
            ShoppingItems = new ObservableCollection<ShoppingItem>(items);
        }

        private void AddItem()
        {
            string newItemName = ItemName.Trim();

            if (!string.IsNullOrWhiteSpace(newItemName))
            {
                ShoppingItem newItem = new ShoppingItem { Name = newItemName }; // Use the Name property
                shoppingListService.AddShoppingItem(newItem);

                LoadShoppingItems(); // Reload the items to update the view
                ItemName = string.Empty; // Clear input field
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
