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
    public partial class WWViewModel:ObservableObject
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
            int productId = product.id;
            var item = ItemsList.FirstOrDefault(p => p.id == productId);
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
        public WWViewModel() {
            CreateItems();
                WWPage.ItemsSource=items;
            void CreateItems()
            {
                
            }

        }
            
        }
        
    }
    

