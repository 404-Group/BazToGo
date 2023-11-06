using BazToGo.Model;
using BazToGo.ViewModels;

namespace BazToGo
{
    public partial class JerrysPage : ContentPage
    {
        public JerrysPage()
        {

            InitializeComponent();
            BindingContext = new JerrysPageViewModel();

        }

        public static IList<Items> ItemsSource { get; internal set; }
    }
}