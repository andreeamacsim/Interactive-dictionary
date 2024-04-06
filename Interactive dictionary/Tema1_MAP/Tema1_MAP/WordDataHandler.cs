using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_MAP
{
    public class WordDataHandler
    {
        private List<Word> words;
        private string filePath;
        public string ImagesDirectory { get; set; }

        public WordDataHandler(string filePath, string imagesDirectory)
        {
            ImagesDirectory = imagesDirectory;
            DefaultImagePath = System.IO.Path.Combine(ImagesDirectory, "Blank"); 
            this.filePath = filePath;
            LoadWordsFromFile();
        }
        public string DefaultImagePath { get; set; }


        public  void LoadWordsFromFile()
        {
            words = new List<Word>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        words.Add(new Word
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
                Console.WriteLine($"Error reading dictionary file: {ex.Message}");
            }
        }

        public List<Word> GetWords()
        {
            return words;
        }

        public void SaveWordsToFile()
        {
            try
            {
                List<string> lines = words.Select(w => $"{w.Name},{w.Description},{w.Category},{w.ImagePath}").ToList();
                File.WriteAllLines(filePath, lines);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to dictionary file: {ex.Message}");
            }
        }

        public void AddWord(Word newWord)
        {
            words.Add(newWord);
            SaveWordsToFile();
        }

        public void UpdateWord(string wordToUpdate, string newDescription, string newCategory, string newImagePath)
        {
            var word = words.FirstOrDefault(w => string.Equals(w.Name, wordToUpdate, StringComparison.OrdinalIgnoreCase));

            if (word != null)
            {
                if (!string.IsNullOrEmpty(newDescription))
                {
                    word.Description = newDescription;
                }

                if (!string.IsNullOrEmpty(newCategory))
                {
                    word.Category = newCategory;
                }

                if (!string.IsNullOrEmpty(newImagePath))
                {
                    word.ImagePath = newImagePath;
                }

                SaveWordsToFile();
            }
        }

        public void DeleteWord(string wordToDelete)
        {
            words.RemoveAll(w => string.Equals(w.Name, wordToDelete, StringComparison.OrdinalIgnoreCase));
            SaveWordsToFile();
        }

        public bool ValidateWordInput(string word, string description, string category)
        {
            return !string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(category);
        }

        public string openFileDialogForImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string destinationPath = Path.Combine(appDirectory, "Images", Path.GetFileName(imagePath));

                File.Copy(imagePath, destinationPath, true);

                return destinationPath;
            }
            else
            {
                return DefaultImagePath;
            }
        }
    }
}
