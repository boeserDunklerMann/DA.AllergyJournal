using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DA.AllergyJournal.Model;

namespace DA.AllergyJournal.MAUI.MVVM;

public partial class SymptomViewVM(DbContext ctx) : ObservableObject
{
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	private double _naseWert;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	private double _augenWert;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	private double _lungeWert;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(GesamtScore))]
	private double _hautWert;

	// Runden auf diskrete Ganzzahlen (0 bis 3)
	partial void OnNaseWertChanged(double value) => NaseWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnAugenWertChanged(double value) => AugenWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnLungeWertChanged(double value) => LungeWert = Math.Clamp(Math.Round(value), 0, 3);
	partial void OnHautWertChanged(double value) => HautWert = Math.Clamp(Math.Round(value), 0, 3);

	public int GesamtScore =>
		(int)(Math.Round(NaseWert) + Math.Round(AugenWert) + Math.Round(LungeWert) + Math.Round(HautWert));

	[ObservableProperty]
	private DateTime _dateWert;

	[RelayCommand]
	private void Reset()
	{
		NaseWert = 0;
		AugenWert = 0;
		LungeWert = 0;
		HautWert = 0;
	}

	[RelayCommand]
	private async Task SaveAsync()
	{
		// TODO DA: Werte (0..3) in Datenbank oder API speichern
		//await Shell.Current.DisplayAlertAsync(
		//	"Erfasst",
		//	$"Nase: {NaseWert:F0}, Augen: {AugenWert:F0}, Lunge: {LungeWert:F0}, Haut: {HautWert:F0}",
		//	"OK");
		DailyJournalEntry today = ctx.CreateDailyEntry(DateWert, (int)Math.Round(NaseWert), (int)Math.Round(AugenWert),
			(int)Math.Round(LungeWert), (int)Math.Round(HautWert));
		await ctx.SaveAsync(today);
	}
}