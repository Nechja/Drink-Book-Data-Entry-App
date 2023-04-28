using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Drink_Book_Data_Entry_App;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<Views.DrinksView>();
		builder.Services.AddSingleton<Views.EntryView>();
		builder.Services.AddSingleton<Views.MenuView>();


		builder.Services.AddSingleton<ViewModels.DataEntryViewModel>();
		builder.Services.AddSingleton<ViewModels.MenuViewModel>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
