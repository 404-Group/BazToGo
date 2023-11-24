using BazToGo.ViewModels;
using BazToGo.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace BazToGo
{
    public partial class JerrysPage : ContentPage
    {
        public static readonly BindableProperty ProductProperty =
            BindableProperty.Create(nameof(Items), typeof(IEnumerable<Items>), typeof(Items), Enumerable.Empty<Items>());
        public JerrysPage()
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
        string previous = (e.PreviousSelection.FirstOrDefault() as Items)?.Name;
        _ = (e.CurrentSelection.FirstOrDefault() as Items)?.Name;
    }

    public static IList<Items> ItemsSource { get; internal set; }
    }

 }
 
