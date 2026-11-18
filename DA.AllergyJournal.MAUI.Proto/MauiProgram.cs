using Microsoft.Extensions.Logging;

namespace DA.AllergyJournal.MAUI.Proto
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">db-singleton injected (ToDo-Nr. #2)</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">MainPage und MainPageVM im DI-Container registriert</Change>
	/// </ChangeLog>
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

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services.AddSingleton(_ => new Model.DbContext(Path.Combine(FileSystem.AppDataDirectory, "app.db3")));
			builder.Services.AddTransient<MVVM.MainPageVM>();
			builder.Services.AddTransient<MainPage>();

			return builder.Build();
		}
	}
}
