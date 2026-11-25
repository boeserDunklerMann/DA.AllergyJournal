using CommunityToolkit.Mvvm.ComponentModel;
using DA.AllergyJournal.MAUI.Services;
using DA.AllergyJournal.Model;

namespace DA.AllergyJournal.MAUI.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class DashboardVM(DbContext ctx, INavigationService nav) : ObservableObject
	{
		#region private fields
		private List<DailyJournalEntry> allDays = [];
		#endregion
		#region UI-bound props
		public string? AvgSeverityFormatted
		{
			get
			{
				if (allDays.Count > 0)
					return allDays.Average(day => (int)day.Nose + (int)day.Eyes + (int)day.Lung + (int)day.Skin).ToString("0.0");
				return "0";
			}
		}
		public string? SymptomFreeDaysText
		{
			get
			{
				if (allDays.Count > 0)
					return allDays.Count(day => (day.Nose == LevelOfPain.Nothing) && (day.Eyes == LevelOfPain.Nothing) && (day.Lung == LevelOfPain.Nothing) && (day.Skin == LevelOfPain.Nothing)).ToString();
				return "n/a";
			}
		}
		public string? TopTriggerName => "unbekannt";
		/// <summary>
		/// Anzahl der Tage, an welchen Medikamente genommen wurden
		/// </summary>
		public string? LoggedDaysText
		{
			get
			{
				if (allDays.Count > 0)
				{
					int anzahl = allDays.Count(day => !string.IsNullOrEmpty(day.Medicine));
					return anzahl == 1 ? "ein Tag erfasst" : $"{anzahl} Tage erfasst";
				}
				return "";
			}
		}
		#endregion
		#region Commands
		private async Task CloseAsync()
		{
			if (!nav.CanGoBack)
				return;
			await nav.GoBackAsync();
		}
		#endregion
		public async Task OnInit()
		{
			allDays = await ctx.GetDailyJournalEntriesAsync();
			OnPropertyChanged("");
		}
	}
}