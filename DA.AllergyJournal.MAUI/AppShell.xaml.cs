namespace DA.AllergyJournal.MAUI
{
	public partial class AppShell : Shell
	{
		/// <summary>Route für einen neuen Eintrag (SymptomPage als Unterseite mit Zurück-Navigation).</summary>
		public const string ErfassenNeuRoute = "ErfassenNeu";
		public const string Dashboard = "Dashboard";
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(ErfassenNeuRoute, typeof(Views.SymptomPage));
			Routing.RegisterRoute(Dashboard, typeof(Views.Dashboard));
		}
	}
}
