using BazToGo.ViewModels;

namespace BazToGo.Controls;

public partial class CartControl : ContentPage
{
    private readonly CartPageViewModel viewModel;
    public static readonly BindableProperty CountProperty =
       BindableProperty.Create(nameof(Count), typeof(int), typeof(CartControl), 0, propertyChanged: OnCountChanged);
    public CartControl()
    {
        InitializeComponent();
        viewModel = new CartPageViewModel();
        BindCountLabel();
    }
    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }
    private void BindCountLabel()
    {
        Binding countBind = new Binding();
        countBind.Source = viewModel.Count;
        countlbl.SetBinding(Label.TextProperty, countBind);

    }
    private static void OnCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        int oldCount = (int)oldValue;
        int newCount = (int)newValue;

        if (oldCount != newCount)
        {
            var cartControl = (CartControl)bindable;
            if (newCount < 1)
            {
            }
            else if (oldCount < 1 && newCount > 1)
            {
            }
            else
            {

            }
        }
    }
}
    