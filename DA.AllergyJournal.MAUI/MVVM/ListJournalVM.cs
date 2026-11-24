using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DA.AllergyJournal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DA.AllergyJournal.MAUI.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="24.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class ListJournalVM(DbContext ctx, Services.INavigationService nav) : ObservableObject
	{
		/// <summary>Öffnet die SymptomPage als Unterseite, um einen neuen Eintrag zu erfassen.</summary>
		[RelayCommand]
		private Task NeuesElementHinzufuegenAsync() => nav.GoToAsync(AppShell.ErfassenNeuRoute);
		public async Task OnInit()
		{
			await Task.CompletedTask;
		}
	}
}