using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Tema1_MAP
{
    public partial class WordSearchView : Window
    {
        private WordSearchLogic logic;

        public WordSearchView()
        {
            InitializeComponent();
            logic = new WordSearchLogic();
            InitializeData();
        }

        private void InitializeData()
        {
            SearchComboBox.ItemsSource = logic.GetAllWordNames();
            SearchComboBox.PreviewKeyDown += SearchComboBox_PreviewKeyDown;
            CategoryComboBox.ItemsSource = logic.ExistingCategories;
            CategoryComboBox.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchComboBox.Text.ToLower();
            string selectedCategory = CategoryComboBox.SelectedItem as string;

            var filteredWords = logic.GetFilteredWords(searchText, selectedCategory);

            PopulateWordList(filteredWords);
        }

        private void PopulateWordList(System.Collections.Generic.List<string> words)
        {
            WordListBox.Items.Clear();
            foreach (var word in words)
            {
                WordListBox.Items.Add(word);
            }
        }

        private void WordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWord = logic.GetSelectedWord(WordListBox.SelectedIndex);

            if (selectedWord != null)
            {
                SelectedWordLabel.Content = "Selected Word: " + selectedWord.Name;
                DescriptionLabel.Content = "Description: " + selectedWord.Description;
                CategoryLabel.Content = "Category: " + selectedWord.Category;

                string imagePath = string.IsNullOrEmpty(selectedWord.ImagePath) ? "Blank.jpg" : selectedWord.ImagePath;
                string imageFullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath);
                ImageBox.Source = new BitmapImage(new Uri(imageFullPath));
            }
        }

        private void SearchComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            string searchText = SearchComboBox.Text.ToLower();
            string selectedCategory = CategoryComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(searchText))
            {
                PopulateWordList(logic.GetAllWordNames());
            }
            else
            {
                var filteredWords = logic.GetFilteredWords(searchText, selectedCategory);
                PopulateWordList(filteredWords);
                UpdateSuggestions(searchText);
            }
        }

        private void UpdateSuggestions(string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                string previousText = SearchComboBox.Text;

                var suggestions = logic.GetAllWordNames()
                    .Where(word => word.ToLower().StartsWith(searchText.ToLower()))
                    .Distinct()
                    .ToList();

                if (suggestions.Count > 0)
                {
                    SearchComboBox.ItemsSource = suggestions;
                    SearchComboBox.Text = previousText; 
                    SearchComboBox.IsDropDownOpen = true;

                    var comboBoxTextBox = (TextBox)SearchComboBox.Template.FindName("PART_EditableTextBox", SearchComboBox);
                    if (comboBoxTextBox != null)
                    {
                        comboBoxTextBox.Select(searchText.Length, previousText.Length - searchText.Length);
                    }
                }
                else
                {
                    SearchComboBox.IsDropDownOpen = false;
                }
            }
            else
            {
                SearchComboBox.IsDropDownOpen = false;
            }
        }


    }
}
