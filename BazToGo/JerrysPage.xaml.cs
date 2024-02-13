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
            Items product = (e.CurrentSelection.FirstOrDefault() as Items);
        int previous = (e.PreviousSelection.FirstOrDefault() as Items).Id;
        _ = (e.CurrentSelection.FirstOrDefault() as Items).Id;
        }

        public static IList<Items> ItemsSource { get; internal set; }
    }

 }
 
