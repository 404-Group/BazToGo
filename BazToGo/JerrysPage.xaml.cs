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
            CreateItems();


            void CreateItems()
            {
                ItemsSource.Add(new Items
                {
                    id = 1,
                    Name = "Burger",
                    Price = 4.99,
                    Image = "burger.png"
                }); ;
                ItemsSource.Add(new Items
                {
                    id = 2,
                    Name = "Grilled Cheese",
                    Price = 4.99,
                    Image = "gcheese.png"
                });

            }
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
 
