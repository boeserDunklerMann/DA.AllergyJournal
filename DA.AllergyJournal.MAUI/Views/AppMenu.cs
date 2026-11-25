namespace DA.AllergyJournal.MAUI.Views;

/// <summary>
/// Hamburger-Menü (☰) rechts oben in der Toolbar einer Seite.
/// </summary>
public static class AppMenu
{
	private const string Uebersicht = "Übersicht";
	private const string Dashboard = "Dashboard";
	private const string Erfassen = "Erfassen";
	private const string Beenden = "Beenden";

	/// <summary>
	/// Fügt der Seite das Hamburger-Menü als rechtestes Toolbar-Element hinzu.
	/// </summary>
	public static void AddTo(Page page) =>
		page.ToolbarItems.Add(new ToolbarItem
		{
			Text = "☰",
			Order = ToolbarItemOrder.Primary,
			Priority = int.MaxValue,
			Command = new Command(async () => await ShowAsync(page))
		});

	private static async Task ShowAsync(Page page)
	{
		string? auswahl = await page.DisplayActionSheetAsync("Menü", "Abbrechen", null, Uebersicht, Dashboard, Erfassen, Beenden);
		switch (auswahl)
		{
			case Uebersicht:
				await Shell.Current.GoToAsync("//ListJournal");
				break;
			case Erfassen:
				// Immer als Unterseite der Übersicht öffnen: Zurück führt zur Liste, kein Stapeln bei Mehrfachaufruf
				await Shell.Current.GoToAsync($"//ListJournal/{AppShell.ErfassenNeuRoute}");
				break;
			case Dashboard:
				await Shell.Current.GoToAsync($"//ListJournal/{AppShell.Dashboard}");
				break;
			case Beenden:
				Application.Current?.Quit();
				break;
		}
	}
}
