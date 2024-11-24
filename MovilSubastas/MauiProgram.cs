using Microsoft.Extensions.Logging;
using MovilSubastas.Services;
using Core.Entities;
using Microsoft.Extensions.Http;
using System.Net.Http.Headers;


namespace MovilSubastas
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddHttpClient<IServicesAPI, ServicesAPI>(client =>
            {
                client.BaseAddress = new Uri("https://nh7s3s43-7073.brs.devtunnels.ms/api/");
            });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IServicesAPI, ServicesAPI>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
