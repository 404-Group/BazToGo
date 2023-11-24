using BazToGo.Model;
using BazToGo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace BazToGo.ViewModels
{

    public partial class CartPageViewModel : ObservableObject
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();
        public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClicked;


        [ObservableProperty]
        private int _count;
        [ObservableProperty]
        private double _total;
        
        [RelayCommand]
     
        public void AddToCart(Items product)
        {
            double total = 0;
            var item = CartItems.FirstOrDefault(c => c.Name == product.Name);
            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                item = new CartItem
                {
                    Name = product.Name,
                    Quantity = 1,
                    Price = product.Price,
                    Image = product.Image
                };
                CartItems.Add(item);
                Count = CartItems.Count;
            }
            for (int i = 0; i < CartItems.Count; i++)
            {
                total = total + CartItems[i].Amount;
            }
        }
        [RelayCommand]
        private void RemoveFromCart(string name)
        {
            var item = CartItems.FirstOrDefault(c => c.Name == name);
            if (item is not null)
            {
                if (item.Quantity == 1)
                {
                    CartItems.Remove(item);
                    Count = CartItems.Count;
                    
                }
                else
                {
                    item.Quantity--;
                }
            }
            for (int i = 0; i < CartItems.Count; i++)
            {
                Total = Total + CartItems[i].Amount;
            }
        }
        public CartPageViewModel() {
            

            var product = new Items {
                Name = "Burger",
                quantity = 1,
                Price = 4.99,
                Image = "burger.png"
            };
            var product2 = new Items
            {
                Name = "Grilled Cheese",
                quantity = 1,
                Price = 4.99,
                Image = "gcheese.png"
            };
            var product3 = new Items
            {
                Name = "Grilled Cheese",
                quantity = 1,
                Price = 4.99,
                Image = "gcheese.png"
            };
            AddToCart(product); 
            AddToCart(product2);
            AddToCart(product3);
            for (int i = 0; i < CartItems.Count; i++)
            {
                Total = Total + CartItems[i].Amount;
            }
        }

        

        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
    }
}
