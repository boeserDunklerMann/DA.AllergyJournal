namespace DA.AllergyJournal.MAUI.Views;

public partial class Dashboard : ContentPage
{
	private MVVM.DashboardVM _viewModel;
	public Dashboard(MVVM.DashboardVM viewModel)
	{
		InitializeComponent();
		AppMenu.AddTo(this);
		BindingContext = _viewModel = viewModel;
	}

	protected override async void OnAppearing()
	{
		await _viewModel.OnInit();
		base.OnAppearing();
	}
}