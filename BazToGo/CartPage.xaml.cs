using BazToGo.Model;
using BazToGo.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        private int check = 0;
        public void RadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (check == 0)
            {
                check = 1;
            }
            else
            {
                check = 0;

            }

        }
        public static ObservableCollection<Items> ItemsSource { get; internal set; }
    }
}