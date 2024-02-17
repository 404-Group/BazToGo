using BazToGo.Model;
using BazToGo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Linq;

namespace BazToGo.ViewModels
{
    public class Popup : Page
    {
        public ProductPageViewModel viewModel = new ProductPageViewModel();

        public async void popup() {
            if (viewModel.SelectedItem == null) {
                await DisplayAlert("Alert","Please select an item from the menu.","OK");
            }
        }


    }
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

    public partial class ProductPageViewModel:ObservableObject
    {
       // public Popup Popup = new Popup();   
        public static ObservableCollection<Items> items = new ObservableCollection<Items>();

        public ObservableCollection<CartItem> CartList = new ObservableCollection<CartItem>();
        public ObservableCollection<Items> JerrysItems = new ObservableCollection<Items>();
        public ObservableCollection<Items> SlimsItems = new ObservableCollection<Items>();
        public ObservableCollection<Items> SushiItems = new ObservableCollection<Items>();
        public ObservableCollection<Items> WWItems = new ObservableCollection<Items>();

        [ObservableProperty]
        public static CartPageViewModel _cartViewModel = new CartPageViewModel();


        [ObservableProperty]
        public Items _selectedItem;
        [ObservableProperty]
        public double _total;
        [ObservableProperty]
        private int _cartCount;
        public static ObservableCollection<Items> ItemsList { get { return items; } }
        public ObservableCollection<Items> JerrysItemsList { get { return JerrysItems; } }
        public ObservableCollection<Items> SlimsItemsList { get { return SlimsItems; } }
        public ObservableCollection<Items> SushiItemsList { get { return SushiItems; } }
        public ObservableCollection<Items> WWItemsList { get { return WWItems; } }



        [RelayCommand]
        private void AddToCart(Items item) => UpdateCart(item, 1);
        [RelayCommand]
        private void RemoveFromCart(Items item) => UpdateCart(item, -1);
        private void UpdateCart(Items product, int count)
        {
            
            if (SelectedItem == null)
            {
                //Popup.popup();
            }
            else
            {
                product = SelectedItem;
                var item = ItemsList.FirstOrDefault(p => p.Id == product.Id);
                if (item != null)
                {
                    item.Quantity += count;
                    if (count == -1)
                    {
                        CartViewModel.RemoveFromCartCommand.Execute(item.Id);
                    }
                    else
                    {
                        CartViewModel.AddToCartCommand.Execute(item);
                    }

                    CartCount = CartViewModel.Count;
                    Total = CartViewModel.Total;
                    Console.WriteLine(Total);
                }
            }
        }
        public ProductPageViewModel() {
            CartPageViewModel _cartViewModel = new CartPageViewModel();
            CreateItems();
            JerrysPage.ItemsSource=JerrysItems;
            SlimsPage.ItemsSource = SlimsItems;
            SushiPage.ItemsSource = SushiItems;
            WWPage.ItemsSource = WWItems;
            void CreateItems()
            {
                items.Add(new Items
                {
                    Id = 1,
                    Name = "Burger",
                    Price = 4.99,
                    Image = "burger.png"
                }); 
                items.Add(new Items
                {
                    Id = 2,
                    Name = "Grilled Cheese",
                    Price = 4.99,
                    Image = "gcheese.png"
                });
                JerrysItems.Add(new Items
                {
                    Id = 1,
                    Name = "Burger",
                    Price = 4.99,
                    Image = "burger.png"
                }); ;
                JerrysItems.Add(new Items
                {
                    Id = 2,
                    Name = "Grilled Cheese",
                    Price = 4.99,
                    Image = "gcheese.png"
                });
                items.Add(new Items
                {
                    Id = 3,
                    Name = "Boba",
                    Price = 3.99,
                    Image = "boba.png"
                }); ;
                items.Add(new Items
                {
                    Id = 4,
                    Name = "California Roll",
                    Price = 3.99,
                    Image = "croll.png"
                });
                items.Add(new Items
                {
                    Id = 10,
                    Name = "Chicks Meal",
                    Price = 5.99,
                    Image = "chicks_plate.png"
                });
                items.Add(new Items
                {
                    Id = 11,
                    Name = "Slims Meal",
                    Price = 6.99,
                    Image = "slims_plate.png"
                }); ;
                items.Add(new Items
                {
                    Id = 12,
                    Name = "Slims Wrap",
                    Price = 5.99,
                    Image = "slims_wrap_meal.png"
                });
                items.Add(new Items
                {
                    Id = 13,
                    Name = "Buffalo Wrap",
                    Price = 5.99,
                    Image = "buffalo_wrap_meal.png"
                });
                items.Add(new Items
                {
                    Id = 14,
                    Name = "Smokey Cheddar Wrap",
                    Price = 4.99,
                    Image = "smokey_cheddar_wrap_meal.png"
                });
                SlimsItems.Add(new Items
                {
                    Id = 10,
                    Name = "Chicks Meal",
                    Price = 5.99,
                    Image = "chicks_plate.png"
                });
                SlimsItems.Add(new Items
                {
                    Id = 11,
                    Name = "Slims Meal",
                    Price = 6.99,
                    Image = "slims_plate.png"
                }); ;
                SlimsItems.Add(new Items
                {
                    Id = 12,
                    Name = "Slims Wrap",
                    Price = 5.99,
                    Image = "slims_wrap_meal.png"
                });
                SlimsItems.Add(new Items
                {
                    Id = 13,
                    Name = "Buffalo Wrap",
                    Price = 5.99,
                    Image = "buffalo_wrap_meal.png"
                });
                SlimsItems.Add(new Items
                {
                    Id = 14,
                    Name = "Smokey Cheddar Wrap",
                    Price = 4.99,
                    Image = "smokey_cheddar_wrap_meal.png"
                });

                SushiItems.Add(new Items
                {
                    Id = 3,
                    Name = "Boba",
                    Price = 3.99,
                    Image = "boba.png"
                }); 
                SushiItems.Add(new Items
                {
                    Id = 4,
                    Name = "California Roll",
                    Price = 3.99,
                    Image = "croll.png"
                });
            }

        }
            
        }
        
    }
    

