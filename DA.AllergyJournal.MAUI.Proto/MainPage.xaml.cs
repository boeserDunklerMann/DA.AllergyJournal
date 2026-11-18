namespace DA.AllergyJournal.MAUI.Proto
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnBtnHelloClicked(object sender, EventArgs e)
		{
			string name = entryName.Text;
			if (string.IsNullOrWhiteSpace(name))
				labelAusgabe.Text = "Gib deinen Namen ein.";
			else
				labelAusgabe.Text = $"Hi {name}!";
		}
	}
}
