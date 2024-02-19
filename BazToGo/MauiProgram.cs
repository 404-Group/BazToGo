using BazToGo.ViewModels;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace BazToGo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ProductPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CartPageViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}