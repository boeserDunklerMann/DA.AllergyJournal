using Microsoft.Extensions.Logging;

namespace DA.AllergyJournal.MAUI
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="24.11.2026" Entwickler="DA">add ListJournalVM</Change>
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
			builder.Services.AddSingleton<Services.INavigationService, Services.ShellNavigationService>();
			builder.Services.AddTransient<MVVM.SymptomViewVM>();
			builder.Services.AddTransient<MVVM.ListJournalVM>();
			builder.Services.AddTransient<MVVM.DashboardVM>();
			builder.Services.AddTransient<Views.SymptomPage>();
			builder.Services.AddTransient<Views.ListJournal>();

			return builder.Build();
		}
	}
}