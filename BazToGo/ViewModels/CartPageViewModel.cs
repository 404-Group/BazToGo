using BazToGo.dtos;
using BazToGo.Model;
using BazToGo.Models;
using System.IO;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Storage;
using System.Threading;

namespace BazToGo.ViewModels
{

    public partial class CartPageViewModel : ObservableObject
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();

        public ObservableCollection<string> PaymentOptions { get; set; } = new();
        

        [ObservableProperty]
        private int _count;
        [ObservableProperty]
        private double _total;
        [ObservableProperty]
        private string _selectedPayment;
        [ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private TimeSpan _selectedTime;
        [ObservableProperty]
        private string _orderType;
        [ObservableProperty]
        private string _delInstructions;
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
            CreateItems();
            void CreateItems()
            {
                CartItems.Add(new CartItem
                {
                    ProductId = 2,
                    Name = "California Roll",
                    Price = 3.99,
                    Image = "croll.png",
                    Quantity = 1
                }); ;
                CartItems.Add(new CartItem
                {
                    ProductId = 1,
                    Name = "Jerry's Burger",
                    details = "-No Lettuce",
                    Price = 4.99,
                    Image = "burger.png",
                    Quantity = 1
                });
                CartItems.Add(new CartItem
                {
                    ProductId = 2,
                    Name = "Slims Meal",
                    details = "-Honey mustard x2",
                    Price = 7.99,
                    Image = "slims_plate.png",
                    Quantity = 1
                });
                CartItems.Add(new CartItem
                {
                    ProductId = 5,
                    Name = "Matcha Green Tea Latte",
                    details = "-Almond Milk" +
                    "\n-Vanilla Syrup",
                    Price = 4.99,
                    Quantity = 1,
                    Image = "cup.png"
                });

            }

            PaymentOptions.Add("Meal Trade" );
            PaymentOptions.Add("DCB");
            PaymentOptions.Add("Debit/Credit");
            for (int i = 0; i < CartItems.Count; i++) {
                Total = Total + CartItems[i].Amount;
            }
            for (int i = 0; i < CartItems.Count; i++)
            {
                Count += CartItems[i].Quantity;
            }
        }
        
        public void receipt(string targetFileName)
        {
            
            string testPath = FileSystem.Current.AppDataDirectory;
            string targetFilePath = System.IO.Path.Combine(testPath, targetFileName);
            using (var outputStream = System.IO.File.OpenWrite(targetFilePath))
            using (var writer = new StreamWriter(outputStream))
            {
                writer.WriteLine("Items:");
                for (int i = 0; i < CartItems.Count; i++)
                {
                    writer.WriteLine(CartItems[i].Name);
                    if (CartItems[i].details != null) {
                        writer.WriteLine(CartItems[i].details);
                    }
                }   
                writer.WriteLine("Name:");
                writer.WriteLine("John Doe");
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
                    writer.WriteLine("Delivery Instructions");
                    writer.WriteLine(DelInstructions);
                }
                writer.Close();
                outputStream.Close();
            }
            
            ReadText(targetFilePath);
        }

        public async void ReadText(string docPath)
        {
            using (var fileStream = File.OpenRead(docPath))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null && line.Length > 1)
                {
                    Console.WriteLine(line);
                }

            }
        }
            private void clearCart()
        {
            CartItems.Clear();
            Count = 0;
        }
        
        
    } }
