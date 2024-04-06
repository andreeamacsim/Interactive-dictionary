using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Tema1_MAP
{
    public class EntertainmentGame
    {
        private string[] words;
        private int currentWordIndex = 0;
        private int correctAnswers = 0;
        private Random random = new Random();

        public EntertainmentGame()
        {
            InitializeGame();
        }

        public void InitializeGame()
        {
            string[] allWords = File.ReadAllLines("C:\\Users\\Andreea\\Desktop\\Tema1_MAP\\Tema1_MAP\\dictionary.txt");

            if (allWords.Length < 5)
            {
                MessageBox.Show("The dictionary file does not contain enough words.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            words = allWords.Select(line => line.Split(',')[0].Trim()).OrderBy(x => random.Next()).Take(5).ToArray();
        }

        public string GetCurrentWord()
        {
            return words[currentWordIndex];
        }

        public string GetRandomHintForCurrentWord()
        {
            string currentWord = GetCurrentWord();
            int randomNumber = random.Next(2);

            if (randomNumber == 0)
            {
                string imagePath = $"C:\\Users\\Andreea\\Desktop\\Tema1_MAP\\Tema1_MAP\\Images\\{currentWord}.jpg";

                if (File.Exists(imagePath))
                {
                    return imagePath;
                }
            }

            string[] allWords = File.ReadAllLines("C:\\Users\\Andreea\\Desktop\\Tema1_MAP\\Tema1_MAP\\dictionary.txt");

            foreach (string line in allWords)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4 && parts[0].Trim() == currentWord)
                {
                    return parts[1].Trim();
                }
            }

            return currentWord;
        }

        public bool IsHintAnImage(string hint)
        {
            return hint?.EndsWith(".png") == true || hint?.EndsWith(".jpg") == true || hint?.EndsWith(".jpeg") == true;
        }

        public bool IsAnswerCorrect(string userAnswer)
        {
            string currentWord = GetCurrentWord();
            return string.Equals(currentWord, userAnswer, StringComparison.OrdinalIgnoreCase);
        }

        public void MoveToNextWord()
        {
            if (currentWordIndex < words.Length - 1)
            {
                currentWordIndex++;
            }
            else
            {
                MessageBox.Show($"Game finished. Correct answers: {correctAnswers}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetGame();
            }
        }

        public void MoveToPreviousWord()
        {
            if (currentWordIndex > 0)
            {
                currentWordIndex--;
            }
        }

        public void ResetGame()
        {
            currentWordIndex = 0;
            correctAnswers = 0;
            InitializeGame();
        }

        public void IncrementCorrectAnswers()
        {
            correctAnswers++;
        }

        public int GetCurrentWordIndex()
        {
            return currentWordIndex;
        }

        
    }
}
