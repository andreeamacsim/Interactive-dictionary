using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace Tema1_MAP
{
    public class WordSearchLogic
    {
        private List<Word> allWords;
        private List<Word> filteredWords;

        public ObservableCollection<string> ExistingCategories { get; private set; }

        public WordSearchLogic()
        {
            ExistingCategories = new ObservableCollection<string>();
            LoadWordsFromFile(@"C:\Users\Andreea\Desktop\Tema1_MAP\Tema1_MAP\dictionary.txt");
            ExistingCategories.Insert(0, "No category");
            LoadCategories();
        }

        private void LoadCategories()
        {
            ExistingCategories.Clear();
            ExistingCategories.Add("No category");

            foreach (var category in allWords.Select(w => w.Category).Distinct())
            {
                ExistingCategories.Add(category);
            }
        }

        private void LoadWordsFromFile(string filePath)
        {
            allWords = new List<Word>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        allWords.Add(new Word
                        {
                            Name = parts[0],
                            Description = parts[1],
                            Category = parts[2],
                            ImagePath = parts[3]
                        });
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading dictionary file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> GetFilteredWords(string searchText, string selectedCategory)
        {
            filteredWords = new List<Word>();

            if (selectedCategory == null || selectedCategory == "No category")
            {
                filteredWords = allWords.Where(word => word.Name.ToLower().StartsWith(searchText)).ToList();
            }
            else
            {
                filteredWords = allWords.Where(word => (string.IsNullOrEmpty(selectedCategory) || word.Category == selectedCategory) && word.Name.ToLower().StartsWith(searchText)).ToList();
            }

            return filteredWords.Select(word => word.Name).ToList();
        }

        public List<string> GetAllWordNames()
        {
            return allWords.Select(word => word.Name).ToList();
        }

        public Word GetSelectedWord(int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < filteredWords.Count)
            {
                return filteredWords[selectedIndex];
            }
            return null;
        }
    }
}
