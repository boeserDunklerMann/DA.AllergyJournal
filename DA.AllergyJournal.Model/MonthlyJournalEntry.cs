using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// <Change Datum="18.11.2026" Entwickler="DA">add Id (ToDo-Nr. #2)</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">Id in JournalEntryBase verschoben</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">DailyJournalEntries wird nicht gespeichert, sondern beim Laden über Month/Year gefüllt</Change>
	/// <Change Datum="18.11.2026" Entwickler="DA">eindeutiger Index auf Year/Month</Change>
	/// </ChangeLog>
	public class MonthlyJournalEntry : JournalEntryBase
	{
		[Indexed(Name = "UX_MonthlyJournalEntry_Year_Month", Order = 2, Unique = true)]
		public int Month { get; set; }
		[Indexed(Name = "UX_MonthlyJournalEntry_Year_Month", Order = 1, Unique = true)]
		public int Year { get; set; }

		/// <summary>Wird nicht gespeichert; DbContext füllt die Liste beim Laden anhand von Month/Year.</summary>
		[Ignore]
		public List<DailyJournalEntry> DailyJournalEntries { get; set; } = [];
		public string? MonthSummary { get; set; }
	}
}