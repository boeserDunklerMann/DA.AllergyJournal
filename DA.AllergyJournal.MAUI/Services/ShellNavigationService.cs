namespace DA.AllergyJournal.MAUI.Services
{
	/// <summary>
	/// Navigation über die .NET MAUI Shell.
	/// </summary>
	/// <ChangeLog>
	/// <Create Datum="24.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public class ShellNavigationService : INavigationService
	{
		public Task GoToAsync(string route, IDictionary<string, object>? parameter = null) =>
			parameter is null
				? Shell.Current.GoToAsync(route)
				: Shell.Current.GoToAsync(route, parameter);

		public bool CanGoBack => Shell.Current.Navigation.NavigationStack.Count > 1;

		public Task GoBackAsync() => Shell.Current.GoToAsync("..");
	}
}
