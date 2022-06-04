using Microsoft.Win32;
using NuGet.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WPF2_FileCloud.Models;

namespace WPF2_FileCloud
{
    /// <summary>
    /// Логика взаимодействия для FileListByUser.xaml
    /// </summary>
    public partial class FileListByUser : Window
    {
        private string userLogin;

        public ObservableCollection<Files> filesList;

        public FileListByUser(string login)
        {
            userLogin = login;

            InitializeComponent();

          //  DataContext = new FileListByUserViewModel(login);

            FileListLabel.Content = "User: " + userLogin;

            //     CreateAsync(login);
            ListViewUpdateAsync();
            listViewFiles.Items.Refresh();
            

     //       listViewFiles.ItemsSource = filesList;
        }

        private static Task CreateAsync(string login)
        {
            var ret = new FileListByUser(login);
            return ret.ListViewUpdateAsync();
        }

        public async Task<List<Files>> ListViewUpdateAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync<List<Files>>("https://localhost:44342/api/Files/" + userLogin);

                filesList = new ObservableCollection<Files>(response);

                listViewFiles.ItemsSource = filesList;

                return response;
            }
        }

        private void AddFilesToListView()
        {

        }

        private bool IsFilesInDB(string login)
        {


            return true;
        }

        private void addFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                AddFileToUser addFile = new AddFileToUser
                {
                    login = userLogin,
                    filePath = ofd.FileName
                    
                };

                addFileToDbAsync(addFile);
                ListViewUpdateAsync();
                listViewFiles.Items.Refresh();
            }

        }

        private async Task addFileToDbAsync(AddFileToUser addFile)
        {
            using (HttpClient client = new HttpClient())
            {
                
                var response = await client.PostAsJsonAsync("https://localhost:44342/api/Files/Insert", addFile);
                //           response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                 //   message.Content = $"Server error code {response.StatusCode}";
                }
            }
        }


        private void updateFileButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewUpdateAsync();
            listViewFiles.Items.Refresh();
        }
    }
}
