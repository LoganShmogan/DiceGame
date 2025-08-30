namespace DiceGamePrac;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnStartGameClicked(object sender, EventArgs e)
	{
		string player1 = Player1Entry.Text?.Trim();
		string player2 = Player2Entry.Text?.Trim();

		if (string.IsNullOrEmpty(player1) || string.IsNullOrEmpty(player2))
		{
			await DisplayAlert("Error", "Please enter both player names!", "OK");
			return;
		}

		// Pass names to GamePage
		await Navigation.PushAsync(new GamePage(player1, player2));
	}
}
