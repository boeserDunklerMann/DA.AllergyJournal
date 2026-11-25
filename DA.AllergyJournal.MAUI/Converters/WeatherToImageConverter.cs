using DA.AllergyJournal.MAUI.MVVM;
using DA.AllergyJournal.Model;
using System.Globalization;

namespace DA.AllergyJournal.MAUI.Converters
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>Wandelt einen Weather-Wert in das zugehörige Bild aus Resources/Images um (null bei unbekanntem Wert).</summary>
	public class WeatherToImageConverter : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
			value is Weather weather
				? WeatherOption.All.FirstOrDefault(o => o.Value == weather)?.Image
				: null;

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
			throw new NotSupportedException();
	}
}
