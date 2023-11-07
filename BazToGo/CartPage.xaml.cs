using BazToGo.Model;
using BazToGo.ViewModels;
using System.Collections.ObjectModel;

namespace BazToGo
{
    public partial class CartPage : ContentPage
    {
        private readonly CartPageViewModel viewModel;
        public CartPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public static ObservableCollection<Items> ItemsSource { get; internal set; }
    }
}