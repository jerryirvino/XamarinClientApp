using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace XamarinClientApp.ViewModel
{
    public class CariKategori : BindableObject
    {
        private RestClient _client =
             new RestClient("http://72140053inventorydb.azurewebsites.net/");

        private ObservableCollection<BarangViewModel> listBarang;
        public ObservableCollection<BarangViewModel> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        public async void RefreshDataAsync(string namaKategori)
        {
            var _request = new RestRequest("api/Barang/?namaKategori=" + namaKategori, Method.GET);
            var _response = await _client.Execute<List<BarangViewModel>>(_request);
            ListBarang = new ObservableCollection<BarangViewModel>(_response.Data);
        }

        public CariKategori(string namaKategori)
        {
            RefreshDataAsync(namaKategori);
        }
    }
}
