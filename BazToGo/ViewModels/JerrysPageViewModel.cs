using BazToGo.Model;
using CommunityToolkit.Mvvm.ComponentModel;
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

    public partial class JerrysPageViewModel:ObservableObject
    {
        public Items selectedItem { get; set; }
        public ObservableCollection<Items> items = new ObservableCollection<Items>();
        private readonly CartPageViewModel _cartViewModel;

        [ObservableProperty]
        private int _cartCount;
        public ObservableCollection<Items> ItemsList { get { return items; } }


        [RelayCommand]
        private void AddToCart(Items item) => UpdateCart(item, 1);
        [RelayCommand]
        private void RemoveFromCart(Items item) => UpdateCart(item, -1);
        private void UpdateCart(Items product, int count)
        {
            var item = ItemsList.FirstOrDefault(x => x.Name == product.Name);
            if (item != null)
            {
                item.cartQuantity += count;
                if (count == -1)
                {
                    _cartViewModel.RemoveFromCartCommand.Execute(product.Name);
                }
                else { 
                    _cartViewModel.AddToCartCommand.Execute(product);
                }

                CartCount = _cartViewModel.Count; 
            }
        }
        public JerrysPageViewModel() {
            CreateItems();

            JerrysPage.ItemsSource = items;

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
