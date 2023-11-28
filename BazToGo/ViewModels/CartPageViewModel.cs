﻿using BazToGo.dtos;
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
            var item = CartItems.FirstOrDefault(c => c.ProductId == product.id);
            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                item = new CartItem
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    ProductId = product.id,
                    Quantity = 1,
                    Price = product.Price,
                    Image = product.Image
                };
                CartItems.Add(item);
                for (int i = 0; i < CartItems.Count; i++)
                {
                    Count += CartItems[i].Quantity;
                }

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
                    for (int i = 0; i < CartItems.Count; i++)
                    {
                        Count += CartItems[i].Quantity;
                    }
                }

                else
                {
                    item.Quantity--; ;
                }
            }
        }
        public CartPageViewModel() {

            for (int i = 0; i < CartItems.Count; i++) {
                Total = Total + CartItems[i].Amount;
            }

        }
        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
        
        
    } }
