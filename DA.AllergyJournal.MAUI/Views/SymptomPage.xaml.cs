namespace DA.AllergyJournal.MAUI.Views
{
	/// <ChangeLog>
	/// <Create Datum="23.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class SymptomPage : ContentPage
	{
		private readonly MVVM.SymptomViewVM _viewModel;
		public SymptomPage(MVVM.SymptomViewVM viewModel)
		{
			InitializeComponent();
			BindingContext = _viewModel = viewModel;
			AppMenu.AddTo(this);
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
		}
	}
}