using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DA.AllergyJournal.MAUI.Proto.MVVM
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	internal class MainPageVM : Framework.BaseViewModel
	{
		#region UI-bound props
		public string Usersname { get; set; } = "";
		private string _greeting = "";
		public string Greeting
		{
			get => _greeting;
			set
			{
				if (_greeting != value)
				{
					_greeting = value;
					RaisePropChanged();
				}
			}
		}
		#endregion

		#region UI-bound commands
		public ICommand ButtonClickCommand => new Framework.DelegateCommand(OnButtonClick);
		#endregion

		private async void OnButtonClick()
		{
			if (string.IsNullOrWhiteSpace(Usersname))
				Greeting = "Gib deinen Namen ein, du Torfnase!";
			else
				Greeting = $"Hi {Usersname}!";
			await Task.CompletedTask;
		}
	}
}