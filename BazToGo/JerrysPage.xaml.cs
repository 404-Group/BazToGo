using BazToGo.ViewModels;
using BazToGo.Model;

namespace BazToGo
{
    public partial class JerrysPage : ContentPage
    {
        public IList<Items> ItemsList { get; set; }
        JerrysPageViewModel viewModel;
        public JerrysPage()
        {
            InitializeComponent();
            viewModel = new JerrysPageViewModel();

        }
    }
}