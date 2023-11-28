using BazToGo.ViewModels;

namespace BazToGo.Controls;

public partial class CartControl : ContentPage
{
    private readonly CartPageViewModel viewModel;
    public static readonly BindableProperty CountProperty =
       BindableProperty.Create(nameof(Count), typeof(int), typeof(CartControl), 0);
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
    
    
}
    