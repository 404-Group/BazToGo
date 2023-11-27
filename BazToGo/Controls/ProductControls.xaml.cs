using BazToGo.dtos;
using BazToGo.Model;
using BazToGo.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BazToGo.Controls;

public class ProductCartItemChangeEventArgs : EventArgs
{
    public int Id { get; set; }
    public int Count { get; set; }



    public ProductCartItemChangeEventArgs(int id, int count)
    {
        id = Id;
        Count = count;
    }
}

public partial class ProductControls : ContentView
{

    public Items selectedItem { get; set; }
    public ObservableCollection<Items> Items = new ObservableCollection<Items>();
    private readonly JerrysPageViewModel _jerryPageViewModel;
    public ObservableCollection<Items> ItemsList { get { return Items; } }
    public static readonly BindableProperty ProductsProperty =
        BindableProperty.Create(nameof(ItemsList), typeof(ObservableCollection<Items>), typeof(ProductControls),0);


    public ProductControls()
    {
        InitializeComponent();
    }
    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string previous = (e.PreviousSelection.FirstOrDefault() as Items)?.Name;
        _ = (e.CurrentSelection.FirstOrDefault() as Items)?.Name;
    }
    public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClicked;

    [RelayCommand]
    private void AddToCart(int id) =>
        AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(id, 1));

    [RelayCommand]
    private void RemoveFromCart(int id) =>
        AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(id, -1));
}
