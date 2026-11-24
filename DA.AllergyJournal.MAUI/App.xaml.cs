namespace DA.AllergyJournal.MAUI
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			Routing.RegisterRoute(AppShell.ErfassenNeuRoute, typeof(Views.SymptomPage));
			return new Window(new AppShell());
		}
	}
}