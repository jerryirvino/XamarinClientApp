﻿using System;
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
    public partial class TambahJenisMotorPage : ContentPage
    {
        public TambahJenisMotorPage()
        {
            InitializeComponent();
            btnTambahJenisMotor.Clicked += BtnTambahJenisMotor_Clicked;
        }

        private RestClient _client =
           new RestClient("http://72140053inventorydb.azurewebsites.net");

        private async void BtnTambahJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.POST);
            var newJenisMotor = new JenisMotor { NamaMerk = txtNamaMerkMotor.Text, NamaJenisMotor = txtNamaJenisMotor.Text };
            _request.AddBody(newJenisMotor);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new JenisMotorPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}