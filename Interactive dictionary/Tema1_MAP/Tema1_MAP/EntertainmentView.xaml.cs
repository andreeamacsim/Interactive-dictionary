using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tema1_MAP
{
    public partial class EntertainmentView : Window
    {
        private EntertainmentGame game;

        public EntertainmentView()
        {
            InitializeComponent();
            game = new EntertainmentGame();
            DisplayWordAndHint();
        }

        private void NextFinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (game.GetCurrentWordIndex() < 4)
            {
                game.MoveToNextWord();
                DisplayWordAndHint();
                UpdateButtonStates();
            }
            else
            {
                MessageBox.Show($"Game finished. Correct answers: {game.GetCurrentWordIndex()}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                game.ResetGame();
            }
        }

        private void DisplayWordAndHint()
        {
            string currentWord = game.GetCurrentWord();
            string currentHint = game.GetRandomHintForCurrentWord();

            if (game.IsHintAnImage(currentHint))
            {
                Uri imageUri = new Uri(currentHint, UriKind.RelativeOrAbsolute);
                HintImage.Source = new BitmapImage(imageUri);
                HintImage.Visibility = Visibility.Visible;
                HintDescription.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintDescription.Text = currentHint;
                HintImage.Visibility = Visibility.Collapsed;
                HintDescription.Visibility = Visibility.Visible;
            }
        }
        private void CheckAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string userAnswer = AnswerTextBox.Text.Trim();

            if (game.IsAnswerCorrect(userAnswer))
            {
                game.IncrementCorrectAnswers();
                CorrectAnswersTextBlock.Text = $"Correct answers: {game.GetCurrentWordIndex()}";
            }
            game.MoveToNextWord();
            DisplayWordAndHint();
            UpdateButtonStates();
        }
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (game.GetCurrentWordIndex() > 0)
            {
                game.MoveToPreviousWord();
                DisplayWordAndHint();
                UpdateButtonStates();
            }
        }
        private void UpdateButtonStates()
        {
            PreviousButton.IsEnabled = game.GetCurrentWordIndex() > 0;
            NextFinishButton.Content = game.GetCurrentWordIndex() < 4 ? "Next" : "Finish";
        }

    }
}