using BazToGo.ViewModels;
using BazToGo.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace BazToGo
{
    public partial class SlimsPage : ContentPage
    {
        public static readonly BindableProperty ProductProperty =
            BindableProperty.Create(nameof(Items), typeof(IEnumerable<Items>), typeof(Items), Enumerable.Empty<Items>());
        public SlimsPage()
        {

            InitializeComponent();
        }


        public IEnumerable<Items> Products
        {
            get => (IEnumerable<Items>)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var previous = (e.PreviousSelection.FirstOrDefault() as Items);
            _ = (e.CurrentSelection.FirstOrDefault() as Items);
        }

        public static IList<Items> ItemsSource { get; internal set; }
    }

}

