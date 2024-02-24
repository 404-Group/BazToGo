using BazToGo.ViewModels;
using Plugin.LocalNotification;
using System.Runtime.CompilerServices;

namespace BazToGo;

public partial class OrderStatusPage : ContentPage
{
    public ProductPageViewModel viewModel = new ProductPageViewModel();
	public string OrderStatus;
	public int OrderStatusId = 0;
	public OrderStatusPage()
	{
		InitializeComponent();
	}

	public async void OrderStatusButtonClicked(object sender, EventArgs args) {
		
		if (OrderStatusId <= 1)	
		{
            OrderStatusId = 1;
			OrderStatus = "Order Confirmed";
			confirm.Color = Color.FromHex("#028A0F");
			prepared.Color = Color.FromHex("D3D3D3");
            preparing.Color = Color.FromHex("D3D3D3");
            complete.Color = Color.FromHex("D3D3D3");
        }
		else if (OrderStatusId == 2)
		{
			OrderStatus = "Order Preparing";
            confirm.Color = Color.FromHex("D3D3D3");
            preparing.Color = Color.FromHex("#028A0F");
            prepared.Color = Color.FromHex("D3D3D3");
            complete.Color = Color.FromHex("D3D3D3");
            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Order is being prepared.",
                CategoryType = NotificationCategoryType.Status
            };
            await LocalNotificationCenter.Current.Show(request);
        }
		else if (OrderStatusId == 3)
		{
			OrderStatus = "Order Prepared";
            confirm.Color = Color.FromHex("D3D3D3");
            preparing.Color = Color.FromHex("D3D3D3");
            prepared.Color = Color.FromHex("#028A0F");
            complete.Color = Color.FromHex("D3D3D3");
            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Order Prepared.",
                CategoryType = NotificationCategoryType.Status
            };
            await LocalNotificationCenter.Current.Show(request);
        }
		else if (OrderStatusId == 4)
		{
			OrderStatus = "Order Picked Up";
            confirm.Color = Color.FromHex("D3D3D3");
            prepared.Color = Color.FromHex("D3D3D3");
            preparing.Color = Color.FromHex("D3D3D3");
            complete.Color = Color.FromHex("#028A0F");
            var request = new NotificationRequest
            {
                NotificationId = 1,
                Title = "Order has been picked up.",
                CategoryType = NotificationCategoryType.Status
            };
            await LocalNotificationCenter.Current.Show(request);
            await Shell.Current.Navigation.PopAsync();
            viewModel.CartViewModel.ReadOrder();
            await Shell.Current.GoToAsync(nameof(CompletedOrderPage));
        }

        status.Text = OrderStatus;
        OrderStatusId++;
        Console.WriteLine(OrderStatus);
        Console.WriteLine(OrderStatusId);
    }
}