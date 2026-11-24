namespace DA.AllergyJournal.MAUI.Views
{
	/// <ChangeLog>
	/// <Create Datum="23.11.2026" Entwickler="DA" />
	/// </ChangeLog>
	public partial class ListJournal : ContentPage
	{
		// TODO DA: add ViewModel
		private readonly MVVM.ListJournalVM _viewModel;
		public ListJournal(MVVM.ListJournalVM viewModel)
		{
			InitializeComponent();
			AppMenu.AddTo(this);
			BindingContext = _viewModel = viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _viewModel.OnInit();
		}
	}
}