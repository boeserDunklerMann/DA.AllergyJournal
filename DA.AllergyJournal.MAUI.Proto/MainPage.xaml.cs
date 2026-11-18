namespace DA.AllergyJournal.MAUI.Proto
{
	public partial class MainPage : ContentPage
	{
		private readonly MVVM.MainPageVM _viewModel;

		public MainPage(MVVM.MainPageVM viewModel)
		{
			InitializeComponent();
			BindingContext = _viewModel = viewModel;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await _viewModel.LoadDataAsync();
		}
	}
}
