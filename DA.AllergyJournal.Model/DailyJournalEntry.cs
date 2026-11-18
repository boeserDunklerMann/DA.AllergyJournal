using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">add Id (ToDo-Nr. #2)</Change>
	/// </ChangeLog>
	public class DailyJournalEntry
	{
		[AutoIncrement, PrimaryKey]
		public int Id { get; set; }
		public DateOnly Date{ get; set; }
		public LevelOfPain Nose { get; set; }
		public LevelOfPain Eyes { get; set; }
		public LevelOfPain Lung { get; set; }
		public LevelOfPain Skin { get; set; }
		public string? Medicine { get; set; }
		public object? Weather { get; set; }    // TODO DA: as part of this https://github.com/boeserDunklerMann/DA.AllergyJournal/issues/3
	}
}