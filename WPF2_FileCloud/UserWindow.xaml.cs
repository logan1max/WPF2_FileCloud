using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF2_FileCloud
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private string login;
        public UserWindow(string _login)
        {
            login = _login;
            InitializeComponent();
        }

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewFilesButton_Click(object sender, RoutedEventArgs e)
        {
            FileListByUser fileListByUser = new FileListByUser(login);
            this.Close();
            
            fileListByUser.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
