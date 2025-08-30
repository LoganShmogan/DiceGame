using Microsoft.Maui.Controls;

namespace DiceGamePrac;

public partial class GamePage : ContentPage
{
    private string _player1;
    private string _player2;
    private int _score1 = 0;
    private int _score2 = 0;
    private Random _rng = new Random();

    public GamePage(string player1, string player2)
    {
        InitializeComponent();
        _player1 = player1;
        _player2 = player2;

        Player1Name.Text = player1;
        Player2Name.Text = player2;
    }

    private async void OnPlayer1Roll(object sender, EventArgs e)
    {
        int roll = _rng.Next(1, 7);
        UpdateDiceImage(roll);
        _score1 += roll;
        Player1ScoreLabel.Text = _score1.ToString();

        if (_score1 >= 20)
        {
            await DisplayAlert("Winner!", $"{_player1} has won the game!", "OK");
            EndGame();
            return;
        }

        Player1RollButton.IsEnabled = false;
        Player2RollButton.IsEnabled = true;
    }

    private async void OnPlayer2Roll(object sender, EventArgs e)
    {
        int roll = _rng.Next(1, 7);
        UpdateDiceImage(roll);
        _score2 += roll;
        Player2ScoreLabel.Text = _score2.ToString();

        if (_score2 >= 20)
        {
            await DisplayAlert("Winner!", $"{_player2} has won the game!", "OK");
            EndGame();
            return;
        }

        Player2RollButton.IsEnabled = false;
        Player1RollButton.IsEnabled = true;
    }

    private void UpdateDiceImage(int roll)
    {
        DiceImage.Source = $"dice{roll}.png"; 
        // Place dice1.png … dice6.png in Resources/Images
        // Set Build Action = MauiImage
    }

    private void EndGame()
    {
        Player1RollButton.IsEnabled = false;
        Player2RollButton.IsEnabled = false;
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        _score1 = 0;
        _score2 = 0;
        Player1ScoreLabel.Text = "0";
        Player2ScoreLabel.Text = "0";
        Player1RollButton.IsEnabled = true;
        Player2RollButton.IsEnabled = false;
        DiceImage.Source = null;
    }
}
