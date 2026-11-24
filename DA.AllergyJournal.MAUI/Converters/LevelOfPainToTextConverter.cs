using DA.AllergyJournal.Model;
using System.Globalization;

namespace DA.AllergyJournal.MAUI.Converters
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="24.11.2026" Entwickler="DA">aus DA.AllergyJournal.MAUI.Proto übernommen</Change>
	/// </ChangeLog>
	/// <summary>Wandelt einen LevelOfPain-Wert in einen deutschen Anzeigetext um.</summary>
	public class LevelOfPainToTextConverter : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
			value switch
			{
				LevelOfPain.Nothing => "keine",
				LevelOfPain.Light => "leicht",
				LevelOfPain.Moderate => "mittel",
				LevelOfPain.Massive => "stark",
				_ => value?.ToString()
			};

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
			value switch
			{
				"keine" => LevelOfPain.Nothing,
				"leicht" => LevelOfPain.Light,
				"mittel" => LevelOfPain.Moderate,
				"stark" => LevelOfPain.Massive,
				_ => throw new NotSupportedException($"Unbekannter Text für LevelOfPain: '{value}'")
			};
	}
}
