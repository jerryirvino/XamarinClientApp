using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Model;
using XamarinClientApp.ViewModel;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace XamarinClientApp
{
    public partial class EditKategoriPage : ContentPage
    {
        public EditKategoriPage()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private RestClient _client =
           new RestClient("http://72140053inventorydb.azurewebsites.net");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Kategori/{KategoriId}", Method.DELETE);
            _request.AddParameter("id", txtIdKategori.Text);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }


        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Kategori", Method.PUT);
            var newKategori = new Kategori
            {
                KategoriId = Convert.ToInt32(txtIdKategori.Text),
                NamaKategori = txtNamaKategori.Text
            };

            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}