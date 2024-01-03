using Maui.CommandPattern.EntityLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore.AutoRegisterDi;
using MudBlazor;
using MudBlazor.Services;

namespace Maui.CommandPattern.BlazorHybrid
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddDbContext<CommandPatternContext>(
                options => options.UseSqlite($"Filename={Constants.SqLiteConstants.GetDatabasePath()}",
                x => x.MigrationsAssembly("Maui.CommandPattern.EntityLibrary")));

            InjectPatternFromAssemblies(builder, "Service");
            InjectPatternFromAssemblies(builder, "Repository");

            return builder.Build();
        }

        static void InjectPatternFromAssemblies(MauiAppBuilder builder, string pattern)
        {
            builder.Services.RegisterAssemblyPublicNonGenericClasses()
                    .Where(c => c.Name.EndsWith(pattern, StringComparison.CurrentCultureIgnoreCase))
                    .AsPublicImplementedInterfaces();
        }
    }
}
