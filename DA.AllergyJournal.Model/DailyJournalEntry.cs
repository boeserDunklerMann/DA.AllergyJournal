using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">add Id (ToDo-Nr. #2)</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">Id in JournalEntryBase verschoben</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">Weather mit [Ignore] markiert</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">Date intern als DateTime (StoredDate) speichern, da sqlite-net kein DateOnly kennt</Change>
	/// <Change Datum="25.11.2026" Entwickler="DA">Weather-enum added</Change>
	/// </ChangeLog>
	public class DailyJournalEntry : JournalEntryBase
	{
		/// <summary>sqlite-net kennt DateOnly nicht, daher wird das Datum als DateTime in der Spalte "Date" gespeichert.</summary>
		[Column("Date"), Indexed]
		public DateTime StoredDate { get; set; }

		[Ignore]
		public DateOnly Date
		{
			get => DateOnly.FromDateTime(StoredDate);
			set => StoredDate = value.ToDateTime(TimeOnly.MinValue);
		}
		public LevelOfPain Nose { get; set; }
		public LevelOfPain Eyes { get; set; }
		public LevelOfPain Lung { get; set; }
		public LevelOfPain Skin { get; set; }
		public string? Medicine { get; set; }
		public Weather Weather { get; set; }    // TODO DA: as part of this https://github.com/boeserDunklerMann/DA.AllergyJournal/issues/3
	}
}