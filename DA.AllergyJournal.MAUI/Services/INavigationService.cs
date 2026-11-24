namespace DA.AllergyJournal.MAUI.Services
{
	/// <summary>
	/// Kapselt die Seitennavigation, damit ViewModels weder Shell noch Seiten kennen müssen.
	/// </summary>
	/// <ChangeLog>
	/// <Create Datum="24.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public interface INavigationService
	{
		/// <summary>Navigiert zur angegebenen Route, optional mit Parametern.</summary>
		Task GoToAsync(string route, IDictionary<string, object>? parameter = null);

		/// <summary>True, wenn die aktuelle Seite auf den Navigationsstapel gelegt wurde (Zurück möglich).</summary>
		bool CanGoBack { get; }

		/// <summary>Navigiert eine Seite zurück.</summary>
		Task GoBackAsync();
	}
}
