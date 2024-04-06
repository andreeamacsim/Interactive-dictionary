using System.IO;
using System.Windows;

namespace Tema1_MAP
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            if (AuthenticateUser())
            {

                AdministrativeView adminWindow = new AdministrativeView();
                adminWindow.Show();
                Close();
            }
        }

        private bool AuthenticateUser()
        {
            string usersFilePath = @"C:\Users\Andreea\Desktop\Tema1_MAP\Tema1_MAP\accounts.txt";

            try
            {
                if (!File.Exists(usersFilePath))
                {
                    MessageBox.Show($"User file not found at {usersFilePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                string[] lines = File.ReadAllLines(usersFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string storedUsername = parts[0];
                        string storedPassword = parts[1];

                        if (storedUsername == UsernameTextBox.Text && storedPassword == PasswordBox.Password)
                        {
                            MessageBox.Show("Authentication successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error reading user file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }
 }
