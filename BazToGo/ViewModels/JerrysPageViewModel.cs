using BazToGo.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BazToGo.ViewModels
{
    public class JerrysPageViewModel
    {
        ObservableCollection<Items> items = new ObservableCollection<Items>();
        public ObservableCollection<Items> CartItems { get; set; }
        public Items SelectedItem { get; set; }
        public ICommand CartItemclick { get; set; }
        public ObservableCollection<Items> ItemsList { get { return items; } }

        public JerrysPageViewModel() {
            CreateItems();

            JerrysPage.ItemsSource = items;

            CartItems = new ObservableCollection<Items> { };
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
            async void executeCartitemclickcommand(Items item)
            {
                this.CartItems.Add(this.SelectedItem);
                await Shell.Current.Navigation.PushModalAsync(new CartPage());

            }

            void CreateItems() {
                items.Add(new Items
                {
                    Name = "Burger",
                    Price  ="4.99",
                    Picture = "burger.png"
                });
                items.Add(new Items
                {
                    Name = "Grilled Cheese",
                    Price = "4.99",
                    Picture = "gcheese.png"
                });

            }
        }
    }
    
}
