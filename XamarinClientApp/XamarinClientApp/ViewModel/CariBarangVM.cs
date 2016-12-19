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
    public class CariBarangVM : BindableObject
    {
        private RestClient _client =
              new RestClient("http://72140053inventorydb.azurewebsites.net/");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        public async void RefreshDataAsync(string namaBarang, string sesi)
        {
            RestRequest _request = new RestRequest("api/Barang/?namaBarang=" + namaBarang + "&sesi=" + sesi, Method.GET);

            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }

        public CariBarangVM(string namaBarang, string sesi)
        {
            RefreshDataAsync(namaBarang, sesi);
        }
    } }  