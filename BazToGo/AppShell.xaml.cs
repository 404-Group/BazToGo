namespace BazToGo
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            Routing.RegisterRoute(nameof(JerrysPage), typeof(JerrysPage));
            Routing.RegisterRoute(nameof(SlimsPage), typeof(SlimsPage));
            Routing.RegisterRoute(nameof(WWPage), typeof(WWPage));
            Routing.RegisterRoute(nameof(SushiPage), typeof(SushiPage));
            Routing.RegisterRoute(nameof(StarbucksPage), typeof(StarbucksPage));
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(OrderStatusPage), typeof(OrderStatusPage)); 
            Routing.RegisterRoute(nameof(CompletedOrderPage), typeof(CompletedOrderPage));
            InitializeComponent();
        }
    }
}