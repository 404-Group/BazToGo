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
                    
                };
                CartItems.Add(item);
                Count = CartItems.Count;
                
                for (int i = 0; i < CartItems.Count; i++)
                {
                   total = total + CartItems[i].Amount;
                }
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
                    for (int i = 0; i < CartItems.Count; i++)
                    {
                        Total = Total + CartItems[i].Amount;
                    }
                }
                else
                {
                    item.Quantity--;
                }
            }
        }
        public CartPageViewModel() {
            CreateItems();

            void CreateItems()
            {
                CartItems.Add(new CartItem
                {
                    Name = "Burger",
                    Price = 4.99,
                    Quantity = 1,
                    Image="burger.png"
                });
                for (int i = 0; i < CartItems.Count; i++)
                {
                    Total = Total + CartItems[i].Amount;
                }
            }
            
        }

        

        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
    }
}
