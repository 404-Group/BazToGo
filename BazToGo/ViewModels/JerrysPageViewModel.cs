using BazToGo.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BazToGo.ViewModels
{
    public class JerrysPageViewModel
    {
        public ObservableCollection<Items> CartItems { get; set; }
        public Items SelectedItem { get; set; }
        public ICommand CartItemclick { get; set; }
        public ObservableCollection<Items> ItemsList { get; set; }
        public JerrysPageViewModel() {
            ItemsList = new ObservableCollection<Items> {
                    new Items{
                        Name="Burger",
                        picture="burger.png",
                        Quantity="1",
                        Price="$4.99"
                    }

             };
            CartItems = new ObservableCollection<Items> { };
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
            async void executeCartitemclickcommand(Items item)
            {
                this.CartItems.Add(this.SelectedItem);
                await Shell.Current.Navigation.PushModalAsync(new CartPage());

            }
        }
    }
    
}
