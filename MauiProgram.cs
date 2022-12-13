using ShopMe.Data;
using ShopMe.Helpers;

namespace ShopMe;

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

        string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
        builder.Services.AddSingleton<ListRepository>(s => ActivatorUtilities.CreateInstance<ListRepository>(s, dbPath));
        builder.Services.AddSingleton<ItemRepository>(s => ActivatorUtilities.CreateInstance<ItemRepository>(s, dbPath));

        return builder.Build();
	}
}
