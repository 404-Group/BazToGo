using BazToGo.Model;
using BazToGo.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BazToGo
{
    public partial class CartPage : ContentPage
    {
        private CartPageViewModel viewModel;
        
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
            viewModel.OrderType = ((RadioButton)sender).Content as string;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ((Picker)sender).SelectedItem as string;
            viewModel.SelectedPayment = selected;
        }
        private void OnTimeSelected(object sender, EventArgs e)
        {
            TimeSpan selected = ((TimePicker)sender).Time;
            viewModel.SelectedTime = selected;
        }
        private void DeliveryInstructionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string instruction = ((Editor)sender).Text;
            viewModel.DelInstructions = instruction;
        }
        public void CheckoutButtonClicked(object sender, EventArgs args)
        {
            viewModel.receipt("receipt.txt");
        }
        public static ObservableCollection<Items> ItemsSource { get; internal set; }

        private void PhoneNumberPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string number = ((Entry)sender).Text as string;
            viewModel.PhoneNumber = number;
        }
    }
}