using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DA.AllergyJournal.Model;

namespace DA.AllergyJournal.MAUI.MVVM;

public partial class SymptomViewVM : ObservableObject
{
	private readonly DbContext ctx;
	private readonly Services.INavigationService nav;

	public SymptomViewVM(DbContext ctx, Services.INavigationService nav)
	{
		this.ctx = ctx;
		this.nav = nav;
		DateWert = DateTime.Today;
	}

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	public partial double NaseWert { get; set; }

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	public partial double AugenWert { get; set; }

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	public partial double LungeWert { get; set; }

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	public partial double HautWert { get; set; }

	// Runden auf diskrete Ganzzahlen (0 bis 3)
	partial void OnNaseWertChanged(double value) => NaseWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnAugenWertChanged(double value) => AugenWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnLungeWertChanged(double value) => LungeWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnHautWertChanged(double value) => HautWert = Math.Clamp(Math.Round(value), 0, 3);

	public int GesamtScore =>
		(int)(Math.Round(NaseWert) + Math.Round(AugenWert) + Math.Round(LungeWert) + Math.Round(HautWert));

	[ObservableProperty]
	public partial DateTime DateWert { get; set; }

	/// <summary>Auswahlmöglichkeiten für das Wetter (Bilder aus Resources/Images).</summary>
	public IReadOnlyList<WeatherOption> WetterOptionen => WeatherOption.All;

	/// <summary>Ausgewähltes Wetter, wird beim Speichern nach DailyJournalEntry.Weather übernommen.</summary>
	[ObservableProperty]
	public partial WeatherOption WetterWert { get; set; } = WeatherOption.All[0];

	[RelayCommand]
	private void Reset()
	{
		NaseWert = 0;
		AugenWert = 0;
		LungeWert = 0;
		HautWert = 0;
		DateWert = DateTime.Today;
		WetterWert = WeatherOption.All[0];
	}

	[RelayCommand]
	private async Task SaveAsync()
	{
		// DONE DA: Werte (0..3) in Datenbank oder API speichern
		DailyJournalEntry today = ctx.CreateDailyEntry(DateWert, (int)Math.Round(NaseWert), (int)Math.Round(AugenWert),
			(int)Math.Round(LungeWert), (int)Math.Round(HautWert), WetterWert.Value);
		await ctx.SaveAsync(today);

		// Als Unterseite (aus der Liste geöffnet) zurück zur Liste, als Tab das Formular leeren
		if (nav.CanGoBack)
			await nav.GoBackAsync();
	}

	public async Task OnInit()
	{
		await Task.CompletedTask;
	}
}