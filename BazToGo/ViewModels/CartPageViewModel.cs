﻿
using BazToGo.Model;
using BazToGo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace BazToGo.ViewModels
{

    public partial class CartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CartItem> _cartItems = new ObservableCollection<CartItem>();
        public ObservableCollection<string> PaymentOptions { get; set; } = new();
        ProfileViewModel profile = new ProfileViewModel();

        //public ProductPageViewModel Products = new ProductPageViewModel();

        public ObservableCollection<Order> Orders = new();

        [ObservableProperty]
        private Items _selectedItem;
        [ObservableProperty]
        private int _count;
        [ObservableProperty]
        private double _total;
        [ObservableProperty]
        private string _selectedPayment;
        [ObservableProperty]
        private TimeSpan _selectedTime;
        [ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private string _orderType;
        [ObservableProperty]
        private string _delInstructions;

        [RelayCommand]

        public void AddToCart(Items product)
        {
            var item = CartItems.FirstOrDefault(p => p.ProductId == product.Id);
            if (item != null)
            {
                item.Quantity++;
                Count++;
                Total += item.Price;
            }
            else
            {
                item = new CartItem
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                    Image = product.Image
                };
                CartItems.Add(item);
                Count++;
                Total += item.Price;
            }
        }
        [RelayCommand]
        public void RemoveFromCart(int productId)
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
        public CartPageViewModel()
        {
            PaymentOptions.Add("Meal Trade");
            PaymentOptions.Add("DCB");
            PaymentOptions.Add("Debit/Credit");

        }
        public void receipt(string targetFileName){

                string testPath = FileSystem.Current.AppDataDirectory;
                string targetFilePath = System.IO.Path.Combine(testPath, targetFileName);
                using (var outputStream = System.IO.File.OpenWrite(targetFilePath))
                using (var writer = new StreamWriter(outputStream))
                {
                    writer.WriteLine("Items:");
                    for (int i = 0; i < CartItems.Count; i++)
                    {
                        writer.WriteLine(CartItems[i].Name);
                        if (CartItems[i].Details != null)
                        {
                            writer.WriteLine(CartItems[i].Details);
                        }
                    writer.WriteLine(CartItems[i].Quantity);
                    }
                    writer.WriteLine("Name:");
                    writer.WriteLine(profile.Name);
                    writer.WriteLine("Payment:");
                    writer.WriteLine(SelectedPayment);
                    writer.WriteLine("Phone Number:");
                    writer.WriteLine(PhoneNumber);
                    writer.WriteLine("Order Time:");
                    writer.WriteLine(SelectedTime);
                    writer.WriteLine("Order Type:");
                    writer.WriteLine(OrderType);
                    if (OrderType == "Delivery")
                    {
                        writer.WriteLine("Delivery Instructions:");
                        writer.WriteLine(DelInstructions);
                    }
                    writer.Close();
                    outputStream.Close();
                }
            Console.WriteLine(targetFilePath);
           // ReadOrder(targetFilePath);
            }
        public void ReadOrder(string docPath)
        {
            Order order = new Order();
            using (var fileStream = File.OpenRead(docPath))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null && line.Length > 1)
                {
                    if (line == "Items:")
                    {
                        streamReader.ReadLine();
                    }
                    while (line != "Name: ")
                    {

                        Items item = new Items();
                        if (!line.Contains("-"))
                        {
                            item.Name = line;
                        }
                        else {
                            while (line.Contains('-')) {
                                item.Details = line;
                            }
                        }
                        item.Quantity = 1;
                        order.items.Add(item);
                    }

                }
                Orders.Add(order);

            }
        }
            private void clearCart()

            {
                CartItems.Clear();
                Count = 0;
            }
        public void CheckTotal() {
            for (int i=0;i<CartItems.Count;i++) {
                Total += CartItems[i].Amount;
            }
        }
        
    }
}


