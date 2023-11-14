using BazToGo.ViewModels;
using BazToGo.Model;
using CommunityToolkit.Mvvm.Input;

namespace BazToGo
{
    public class ProductCartItemChangeEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public ProductCartItemChangeEventArgs(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
    public partial class JerrysPage : ContentPage
    {
        public static readonly BindableProperty JerrysProperty =
            BindableProperty.Create(nameof(JerrysPage), typeof(IEnumerable<Items>), typeof(JerrysPage), Enumerable.Empty<Items>());
        public JerrysPage()
        {
            InitializeComponent();
        }

        public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClicked;

        public IEnumerable<Items> Products
        {
            get => (IEnumerable<Items>)GetValue(JerrysProperty);
            set => SetValue(JerrysProperty, value);
        }

        [RelayCommand]
        public void AddToCart(string name) =>
            AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(name, 1));

        [RelayCommand]
        public void RemoveFromCart(string name) =>
            AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(name, -1));
    
    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string previous = (e.PreviousSelection.FirstOrDefault() as Items)?.Name;
        _ = (e.CurrentSelection.FirstOrDefault() as Items)?.Name;
    }

    public static IList<Items> ItemsSource { get; internal set; }
    }

 }
 
