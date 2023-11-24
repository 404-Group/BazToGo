using BazToGo.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;

namespace BazToGo.ViewModels
{
    public class ProductCartItemChangeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public ProductCartItemChangeEventArgs(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
    public partial class JerrysPageViewModel
    {
        public Items selectedItem { get; set; }
        public ObservableCollection<Items> items = new ObservableCollection<Items>();

        public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClicked;
        public ICommand AddToCart{ private set; get; }

        [RelayCommand]
        public void RemoveFromCart(string name) =>
            AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(name, -1));

        public ObservableCollection<Items> ItemsList { get { return items; } }
    public JerrysPageViewModel() {
            CreateItems();

            JerrysPage.ItemsSource = items;

            AddToCart = new Command<string>(
                    execute: (string name) =>
                {
                    AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(name, 1));
                });

            void CreateItems() {
                items.Add(new Items
                {
                    Name = "Burger",
                    Price  =4.99,
                    Image = "burger.png"
                });
                items.Add(new Items
                {
                    Name = "Grilled Cheese",
                    Price = 4.99,
                    Image = "gcheese.png"
                });
            }
        }
    }
    
}
