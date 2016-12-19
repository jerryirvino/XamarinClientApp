using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Model;
using XamarinClientApp.ViewModel;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class JenisMotorPage : ContentPage
    {
        public JenisMotorPage()
        {
            InitializeComponent();
            btnTambah.Clicked += btnTambahKategori_Clicked;
            listJenisMotor.ItemTapped += ListJenisMotor_ItemTapped;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new JenisMotorViewModel();
        }

        private void ListJenisMotor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            EditJenisMotorPage editPage = new EditJenisMotorPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void btnTambahKategori_Clicked(object sender, EventArgs e)
        {
            TambahJenisMotorPage tambahPage = new TambahJenisMotorPage();
            Navigation.PushAsync(tambahPage);
        }
    }
}