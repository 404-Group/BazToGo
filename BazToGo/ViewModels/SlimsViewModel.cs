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

    public partial class SlimsViewModel:ObservableObject
    {
        public Items SelectedItem { get; set; }
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
            var item = ItemsList.FirstOrDefault(p => p.id == product.id);
            if (item != null)
            {
                item.cartQuantity += count;
                if (count == -1)
                {
                    _cartViewModel.RemoveFromCartCommand.Execute(item.id);
                }
                else { 
                    _cartViewModel.AddToCartCommand.Execute(item);
                }

                CartCount = _cartViewModel.Count; 
            }
        }
        public SlimsViewModel() {
            CreateItems();
                SlimsPage.ItemsSource=items;
            void CreateItems()
            {
                items.Add(new Items
                {
                    id = 10,
                    Name = "Chicks Meal",
                    Price = 5.99,
                    Image = "chicks_plate.png"
                });
                items.Add(new Items
                {
                    id = 10,
                    Name = "Slims Meal",
                    Price = 6.99,
                    Image = "slims_plate.png"
                }); ;
                items.Add(new Items
                {
                    id = 11,
                    Name = "Slims Wrap",
                    Price = 5.99,
                    Image = "slims_wrap_meal.png"
                }) ;
                items.Add(new Items
                {
                    id = 11,
                    Name = "Buffalo Wrap",
                    Price = 5.99,
                    Image = "buffalo_wrap_meal.png"
                });
                items.Add(new Items
                {
                    id = 11,
                    Name = "Smokey Cheddar Wrap",
                    Price = 4.99,
                    Image = "smokey_cheddar_wrap_meal.png"
                });

            }

        }
            
        }
        
    }
    

