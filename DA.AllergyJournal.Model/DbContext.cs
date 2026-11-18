using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DA.AllergyJournal.Model
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public class DbContext(string databasePath)
	{
		private SQLiteAsyncConnection? _db;

		private async Task Init()
		{
			if (_db != null) return;
			_db = new SQLiteAsyncConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
			await _db.CreateTableAsync<MonthlyJournalEntry>();
			await _db.CreateTableAsync<DailyJournalEntry>();
		}

		public async Task<List<DailyJournalEntry>> GetDailyJournalEntriesAsync()
		{
			await Init();
			return await _db!.Table<DailyJournalEntry>().ToListAsync();
		}

		public async Task<List<MonthlyJournalEntry>> GetMonthlyJournalEntriesAsync()
		{
			await Init();
			var months = await _db!.Table<MonthlyJournalEntry>().ToListAsync();
			foreach (var month in months)
				month.DailyJournalEntries = await GetDailyJournalEntriesAsync(month.Year, month.Month);
			return months;
		}

		public async Task<List<DailyJournalEntry>> GetDailyJournalEntriesAsync(int year, int month)
		{
			await Init();
			var from = new DateTime(year, month, 1);
			var to = from.AddMonths(1);
			return await _db!.Table<DailyJournalEntry>()
				.Where(d => d.StoredDate >= from && d.StoredDate < to)
				.OrderBy(d => d.StoredDate)
				.ToListAsync();
		}

		public async Task<int> SaveAsync(JournalEntryBase entry)
		{
			await Init();
			return entry.Id != 0 ? await _db!.UpdateAsync(entry) : await _db!.InsertAsync(entry);
		}
	}
}