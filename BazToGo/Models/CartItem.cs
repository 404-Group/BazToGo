using CommunityToolkit.Mvvm.ComponentModel;

namespace BazToGo.Models
{
    public partial class CartItem : ObservableObject
    {
        public Guid Id { get; set; }
        [ObservableProperty]
        public int _productId;

        [ObservableProperty]
        public string _name;

        [ObservableProperty]
        public string _details;

        [ObservableProperty]
        public double _price;

        [ObservableProperty]
        public string _image;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        public int _quantity;

        public double Amount => Price * Quantity;
    }
}
