namespace DA.AllergyJournal.MAUI.Proto
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MVVM.MainPageVM viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}
