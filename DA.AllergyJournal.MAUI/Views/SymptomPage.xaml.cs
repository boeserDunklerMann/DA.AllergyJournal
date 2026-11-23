namespace DA.AllergyJournal.MAUI.Views
{
	/// <ChangeLog>
	/// <Create Datum="18.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class SymptomPage : ContentPage
	{
		private readonly MVVM.SymptomViewVM _viewModel;
		public SymptomPage(MVVM.SymptomViewVM viewModel)
		{
			InitializeComponent();
			BindingContext = _viewModel = viewModel;
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}