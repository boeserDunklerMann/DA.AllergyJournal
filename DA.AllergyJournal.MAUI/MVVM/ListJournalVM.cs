using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DA.AllergyJournal.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DA.AllergyJournal.MAUI.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="24.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class ListJournalVM(DbContext ctx, Services.INavigationService nav) : ObservableObject
	{
		#region Commands
		/// <summary>Öffnet die SymptomPage als Unterseite, um einen neuen Eintrag zu erfassen.</summary>
		[RelayCommand]
		private Task NeuesElementHinzufuegenAsync() => nav.GoToAsync(AppShell.ErfassenNeuRoute);
		#endregion

		#region UI-bound props
		public ObservableCollection<Model.DailyJournalEntry> Dailies { get; set; } = [];
		#endregion

		public async Task OnInit()
		{
			var dailies = await ctx.GetDailyJournalEntriesAsync();
			if (dailies!=null)
			{
				Dailies.Clear();
				dailies.ForEach(d => Dailies.Add(d));
			}
		}
	}
}