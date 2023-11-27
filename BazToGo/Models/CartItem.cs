using CommunityToolkit.Mvvm.ComponentModel;

namespace BazToGo.Models
{
    public partial class CartItem : ObservableObject
    {
        public Guid Id { get; set; }
        public int ProductId {  get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Image { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _quantity;

        public double Amount => Price * Quantity;
    }
}
