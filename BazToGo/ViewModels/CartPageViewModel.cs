using BazToGo.Model;
using BazToGo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace BazToGo.ViewModels
{

    public partial class CartPageViewModel : ObservableObject
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();

        [ObservableProperty]
        private int _count;

        [RelayCommand]
        private void AddToCart(Items product)
        {
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
            }
        }
        [RelayCommand]
        private void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == productId);
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
        }

        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
    }
}
