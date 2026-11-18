using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public abstract class JournalEntryBase
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}
