using CommunityToolkit.Mvvm.ComponentModel;

namespace BazToGo.Models
{
    public partial class CartItem : ObservableObject
    {
        public string Name { get; set; }

        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _quantity;

        public double Amount => Price * Quantity;
    }
}
