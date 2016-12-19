using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;


namespace XamarinClientApp.ViewModel
{
    class JenisMotorViewModel : BindableObject
    {
        private RestClient _client =
           new RestClient("http://72140053inventorydb.azurewebsites.net");

        private ObservableCollection<JenisMotor> listJenisMotor;
        public ObservableCollection<JenisMotor> ListJenisMotor
        {
            get { return listJenisMotor; }
            set { listJenisMotor = value; OnPropertyChanged("ListJenisMotor"); }
        }

        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/JenisMotor", Method.GET);
            var _response = await _client.Execute<List<JenisMotor>>(_request);
            ListJenisMotor = new ObservableCollection<JenisMotor>(_response.Data);
        }

        public JenisMotorViewModel()
        {
            RefreshDataAsync();
        }
    }
}