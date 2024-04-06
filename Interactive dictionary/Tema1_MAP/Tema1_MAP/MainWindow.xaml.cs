using System.Collections.Generic;
using System.Windows;

namespace Tema1_MAP
{
    public partial class MainWindow : Window
    {
        private List<User> users;
        public MainWindow()
        {
            InitializeComponent();
        }
      

        private void OpenAdministrativeModule(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void OpenWordSearchModule(object sender, RoutedEventArgs e)
        {
            WordSearchView wordSearchWindow = new WordSearchView();
            wordSearchWindow.Show();
            Close();
        }

        private void OpenEntertainmentModule(object sender, RoutedEventArgs e)
        {
            EntertainmentView entertainmentWindow = new EntertainmentView();
            entertainmentWindow.Show();
            Close();
        }
    }
}
