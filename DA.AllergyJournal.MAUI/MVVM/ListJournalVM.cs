using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DA.AllergyJournal.Model;
using System.Collections.ObjectModel;

namespace DA.AllergyJournal.MAUI.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="24.11.2026" Entwickler="DA" />
	/// <Change Datum="24.11.2026" Entwickler="DA">Pull-to-Refresh (AktualisierenCommand, WirdGeladen)</Change>
	/// </ChangeLog>
	public partial class ListJournalVM(DbContext ctx, Services.INavigationService nav) : ObservableObject
	{
		#region Commands
		/// <summary>Öffnet die SymptomPage als Unterseite, um einen neuen Eintrag zu erfassen.</summary>
		[RelayCommand]
		private Task NeuesElementHinzufuegenAsync() => nav.GoToAsync(AppShell.ErfassenNeuRoute);

		/// <summary>Pull-to-Refresh: lädt die Einträge neu. Die RefreshView setzt WirdGeladen beim Ziehen selbst auf true.</summary>
		[RelayCommand]
		private async Task AktualisierenAsync()
		{
			try
			{
				await LadenAsync();
			}
			finally
			{
				WirdGeladen = false;
			}
		}
		#endregion

		#region UI-bound props
		public ObservableCollection<Model.DailyJournalEntry> Dailies { get; set; } = [];

		/// <summary>Steuert die Lade-Anzeige der RefreshView.</summary>
		[ObservableProperty]
		public partial bool WirdGeladen { get; set; }
		#endregion

		public Task OnInit() => LadenAsync();

		private async Task LadenAsync()
		{
			var dailies = await ctx.GetDailyJournalEntriesAsync();
			if (dailies != null)
			{
				Dailies.Clear();
				// neueste Einträge oben
				foreach (var d in dailies.OrderByDescending(d => d.StoredDate))
					Dailies.Add(d);
			}
		}
	}
}
