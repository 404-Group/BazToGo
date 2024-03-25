using BazToGo.Model;
using BazToGo.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Plugin.LocalNotification;

namespace BazToGo
{
    public partial class CartPage : ContentPage
    {
        private readonly ProductPageViewModel viewModel;
        private readonly LocationViewModel viewModel2;
        public OrderStatusPage orderStatus;

        public CartPage()
        {
            InitializeComponent();
            viewModel = new ProductPageViewModel();
            viewModel2 = new LocationViewModel();
            LoadLocations();
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
                viewModel.CartViewModel.OrderType = ((RadioButton)sender).Content as string;
            
        }
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ((Picker)sender).SelectedItem as string;
            viewModel.CartViewModel.SelectedPayment = selected;
        }
        private void OnTimeSelected(object sender, EventArgs e)
        {
            TimeSpan selected = ((TimePicker)sender).Time;
            viewModel.CartViewModel.SelectedTime = selected;
        }
        private void DeliveryInstructionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string instruction = ((Editor)sender).Text;
            viewModel.CartViewModel.DelInstructions = instruction;
        }
        public async void CheckoutButtonClicked(object sender, EventArgs args)
        {
            viewModel.CartViewModel.Receipt("receipt.txt");
            await Shell.Current.GoToAsync(nameof(OrderStatusPage));
            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Order Placed.",
                Subtitle = "Order Placed.",
                CategoryType = NotificationCategoryType.Status
            };
            await LocalNotificationCenter.Current.Show(request);
        }
        private void LoadLocations()
        {
            try
            {
                // Call the method to retrieve locations from the ViewModel
                var locations = viewModel2.GetLocationsFromDatabase();

                // Now you can use the retrieved locations as needed
                foreach (var location in locations)
                {
                    // Do something with the location data
                    Console.WriteLine($"Location ID: {location.IDLocation}, Name: {location.LocationName}");
                }
            }
            catch (Exception ex)
            {
                // Handle exception, log or display error message
                Console.WriteLine("Error: " + ex.Message);
                DisplayAlert("Error", "Failed to retrieve locations. Please try again later.", "OK");
            }
        }
        public static ObservableCollection<Items> ItemsSource { get; internal set; }

        private void PhoneNumberPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string number = ((Entry)sender).Text as string;
            viewModel.CartViewModel.PhoneNumber = number;
        }
    }
}