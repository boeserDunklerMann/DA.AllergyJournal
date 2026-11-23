using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DA.AllergyJournal.MAUI.MVVM.Framework
{
	/// <ChangeLog>
		/// <Create Datum="23.11.2026" Entwickler="DA" />
		/// </ChangeLog>
	public class ObservableObject:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void RaisePropChanged([CallerMemberName] string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
