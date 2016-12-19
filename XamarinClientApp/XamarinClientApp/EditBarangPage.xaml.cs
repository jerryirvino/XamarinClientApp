using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XamarinClientApp.Model;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Xamarin.Forms;

namespace XamarinClientApp
{
    public partial class EditBarangPage : ContentPage
    {
        public EditBarangPage()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private RestClient _client =
          new RestClient("http://72140053inventorydb.azurewebsites.net");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang/{KodeBarang}", Method.DELETE);
            _request.AddParameter("id", txtKodeBarang.Text);
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
            var _request = new RestRequest("api/Barang", Method.PUT);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                Nama = txtNamaBarang.Text,
                Stok = txtStok.Text,
                HargaBeli = txtHargaBeli.Text,
                HargaJual = txtHargaJual.Text,
                TanggalBeli = txtTanggalBeli.Text,
            };

            _request.AddBody(newBarang);
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
