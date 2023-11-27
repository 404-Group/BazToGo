using BazToGo.Model;
using BazToGo.ViewModels;
using System.Collections.ObjectModel;

namespace BazToGo
{
    public partial class CartPage : ContentPage
    {
        private readonly CartPageViewModel viewModel;
        public CartPage()
        {
            InitializeComponent();
            viewModel = new CartPageViewModel();
            BindTotalLabel();
        }
        private void BindTotalLabel()
        {
            Binding totalBind = new Binding();
            totalBind.Source = viewModel.Total;
            totalLbl.SetBinding(Label.TextProperty,totalBind);

        }
        void DeliveryCheck()
        {

        }
        void PickupCheck() 
        { 
        
        }
        public static ObservableCollection<Items> ItemsSource { get; internal set; }
    }
}