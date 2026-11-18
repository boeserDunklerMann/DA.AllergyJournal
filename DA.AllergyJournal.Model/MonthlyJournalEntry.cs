namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
		/// <Create Datum="18.11.2026" Entwickler="DA" />
		/// </ChangeLog>
	public class MonthlyJournalEntry
	{
		public int Month { get; set; }
		public int Year { get; set; }
		List<DailyJournalEntry> DailyJournalEntries { get; set; } = [];
		public string? MonthSummary { get; set; }
	}
}
