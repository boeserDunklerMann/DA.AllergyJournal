using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">add Id (ToDo-Nr. #2)</Change>
	/// </ChangeLog>
	public class MonthlyJournalEntry
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
		List<DailyJournalEntry> DailyJournalEntries { get; set; } = [];
		public string? MonthSummary { get; set; }
	}
}