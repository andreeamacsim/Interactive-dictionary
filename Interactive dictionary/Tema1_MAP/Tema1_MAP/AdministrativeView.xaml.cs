using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Tema1_MAP
{
    public partial class AdministrativeView : Window
    {
        private WordDataHandler wordDataHandler;
        private CategoryHandler categoryHandler;

        public AdministrativeView()
        {
            InitializeComponent();
            string filePath = @"C:\Users\Andreea\Desktop\Tema1_MAP\Tema1_MAP\dictionary.txt";
            string imagesDirectory = @"C:\Users\Andreea\Desktop\Tema1_MAP\Tema1_MAP\Images";

            wordDataHandler = new WordDataHandler(filePath, imagesDirectory);
            categoryHandler = new CategoryHandler(wordDataHandler.GetWords());
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = categoryHandler.GetExistingCategories();
            CategoryComboBox.SelectedIndex = 0;
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string newCategory = NewCategoryTextBox.Text;
            if (!string.IsNullOrEmpty(newCategory) && !categoryHandler.GetExistingCategories().Contains(newCategory))
            {
                categoryHandler.AddCategory(newCategory);
                CategoryComboBox.ItemsSource = categoryHandler.GetExistingCategories();
                CategoryComboBox.SelectedItem = newCategory;
            }
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            string word = WordTextBox.Text;
            string description = DescriptionTextBox.Text;
            string category = CategoryComboBox.Text;

            if (wordDataHandler.ValidateWordInput(word, description, category))
            {
                string newImagePath = wordDataHandler.openFileDialogForImage();
                wordDataHandler.AddWord(new Word
                {
                    Name = word,
                    Description = description,
                    Category = category,
                    ImagePath = newImagePath
                });

                MessageBox.Show("Word added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void UpdateWordButton_Click(object sender, RoutedEventArgs e)
        {
            string wordToUpdate = WordTextBox.Text;
            string newDescription = DescriptionTextBox.Text;
            string newCategory = CategoryComboBox.Text;
            string newImagePath = ImagePathTextBox.Text;

            wordDataHandler.UpdateWord(wordToUpdate, newDescription, newCategory, newImagePath);
        }
        private void DeleteWordButton_Click(object sender, RoutedEventArgs e)
        {
            string wordToDelete = WordTextBox.Text;
            wordDataHandler.DeleteWord(wordToDelete);
        }
        
    }
}
