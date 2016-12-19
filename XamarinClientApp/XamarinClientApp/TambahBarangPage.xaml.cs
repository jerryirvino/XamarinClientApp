﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Model;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class TambahBarangPage : ContentPage
    {
        public TambahBarangPage()
        {
            InitializeComponent();
            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }

        private RestClient _client =
           new RestClient("http://72140053inventorydb.azurewebsites.net");

        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.POST);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                IdJenisMotor = Convert.ToInt32(txtIDJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriID.Text),
                Nama = txtNamaBarang.Text,
                Stok = txtStokBarang.Text,
                HargaBeli = txtHargaBeli.Text,
                HargaJual = txtHargaJual.Text,
                TanggalBeli = txtTglBeli.Text
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new BarangPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}