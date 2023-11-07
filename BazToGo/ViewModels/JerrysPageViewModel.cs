using BazToGo.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BazToGo.ViewModels
{
    public class JerrysPageViewModel
    {
        public Items selectedItem { get; set; }
        ObservableCollection<Items> items = new ObservableCollection<Items>();
        public ObservableCollection<Items> ItemsList { get { return items; } }
        readonly ObservableCollection<Items> CartItems;
        public ICommand AddToCart { private set; get; }
    public JerrysPageViewModel() {
            CreateItems();

            JerrysPage.ItemsSource = items;

            void CreateItems() {
                items.Add(new Items
                {
                    Name = "Burger",
                    Price  =4.99,
                    Picture = "burger.png"
                });
                items.Add(new Items
                {
                    Name = "Grilled Cheese",
                    Price = 4.99,
                    Picture = "gcheese.png"
                });

            }
            
        
        }
    }
    
}
