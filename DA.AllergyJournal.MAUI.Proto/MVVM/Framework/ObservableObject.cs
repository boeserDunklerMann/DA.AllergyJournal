using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DA.AllergyJournal.MAUI.Proto.MVVM.Framework
{
	/// <ChangeLog>
		/// <Create Datum="18.11.2026" Entwickler="DA" />
		/// </ChangeLog>
	internal class ObservableObject:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void RaisePropChanged([CallerMemberName] string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
