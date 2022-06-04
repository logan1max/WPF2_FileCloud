using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF2_FileCloud.Models;

namespace WPF2_FileCloud
{
    public class FileListByUserViewModel : INotifyPropertyChanged
    {
        private Files selectedFile;
        private string userLogin;
        

        public ObservableCollection<Files> FileList { get; set; }
        public Files SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                OnPropertyChanged("SelectedFile");
            }
        }

        public FileListByUserViewModel(string login)
        {
            userLogin = login;

            ListViewUpdateAsync();

            //FileList = new ObservableCollection<Files>
            //{

            //};
        }

        private async void ListViewUpdateAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetFromJsonAsync<List<Files>>("https://localhost:44342/api/Files/" + userLogin);

                FileList = new ObservableCollection<Files>(response);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
