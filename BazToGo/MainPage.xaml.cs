namespace BazToGo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void JerrysTap(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(JerrysPage));
        }
        async void SlimsTap(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(SlimsPage));
        }
        async void SBTap(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(StarbucksPage));
        }
        async void WWTap(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(WWPage));
        }
        async void SushiTap(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync(nameof(SushiPage));
        }
    }
}