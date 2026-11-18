using DA.AllergyJournal.MAUI.Proto.MVVM.Framework;
using DA.AllergyJournal.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DA.AllergyJournal.MAUI.Proto.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">Datatest-stuff added (ToDo-Nr. #2)</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">DbContext nur noch per Konstruktor-Injection, public für DI</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">LoadDataAsync wird beim Anzeigen der Seite aufgerufen, Dailies als einzelne ObservableCollection</Change>
	/// </ChangeLog>
	public class MainPageVM(DbContext ctx) : Framework.BaseViewModel
	{
		#region UI-bound props
		public string Usersname { get; set; } = "";
		private string _greeting = "";
		public string Greeting
		{
			get => _greeting;
			set
			{
				if (_greeting != value)
				{
					_greeting = value;
					RaisePropChanged();
				}
			}
		}
		public ObservableCollection<DailyJournalEntry> Dailies { get; } = [];
		#endregion

		#region UI-bound commands
		public ICommand ButtonClickCommand => new DelegateCommand(OnButtonClick);
		public ICommand ButtonTestDataCommand => new DelegateCommand(OnButtonTestData);
		#endregion

		private async void OnButtonClick()
		{
			if (string.IsNullOrWhiteSpace(Usersname))
				Greeting = "Gib deinen Namen ein, du Torfnase!";
			else
				Greeting = $"Hi {Usersname}!";
			await Task.CompletedTask;
		}

		private async void OnButtonTestData()
		{
			MonthlyJournalEntry month = new MonthlyJournalEntry() { Month = 11, Year = 2026 };
			DailyJournalEntry daily1 = new DailyJournalEntry() { Date = new DateOnly(2026, 11, 17), Eyes = LevelOfPain.Light, Nose = LevelOfPain.Moderate, Lung = LevelOfPain.Nothing, Skin = LevelOfPain.Nothing };
			DailyJournalEntry daily2 = new DailyJournalEntry() { Date = new DateOnly(2026, 11, 18), Eyes = LevelOfPain.Nothing, Nose = LevelOfPain.Moderate, Lung = LevelOfPain.Nothing, Skin = LevelOfPain.Nothing };
			await ctx.SaveAsync(month);
			await ctx.SaveAsync(daily1);
			await ctx.SaveAsync(daily2);
			await LoadDataAsync();
		}

		/// <summary>Wird von MainPage.OnAppearing aufgerufen.</summary>
		public async Task LoadDataAsync()
		{
			var dailies = await ctx.GetDailyJournalEntriesAsync();
			Dailies.Clear();
			foreach (var daily in dailies)
				Dailies.Add(daily);
		}
	}
}