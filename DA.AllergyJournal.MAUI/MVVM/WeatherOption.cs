using DA.AllergyJournal.Model;

namespace DA.AllergyJournal.MAUI.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="25.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	/// <summary>Auswahleintrag für das Wetter: Enum-Wert, Anzeigetext und Bild aus Resources/Images.</summary>
	/// <remarks>SVGs werden von MAUI zur Build-Zeit in PNGs umgewandelt, daher die Endung ".png".</remarks>
	public sealed record WeatherOption(Weather Value, string Text, string Image)
	{
		public static IReadOnlyList<WeatherOption> All { get; } =
		[
			new(Weather.Sunny, "Sonnig", "sonnig.png"),
			new(Weather.Cloudy, "Bewölkt", "bewoelkt.png"),
			new(Weather.Rain, "Regen", "regen.png")
		];
	}
}
