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
    public partial class BarangPage : ContentPage
    {
        public BarangPage()
        {
            InitializeComponent();
            listBarang.ItemTapped += ListBarang_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
            btnCari.Clicked += BtnCari_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModel();
        }

        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            EditBarangPage editPage = new EditBarangPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            TambahBarangPage tambahPage = new TambahBarangPage();
            Navigation.PushAsync(tambahPage);
        }

        private async void BtnCari_Clicked(object sender, EventArgs e)
        {
            CariItemPage cariPage = new CariItemPage();
            Navigation.PushAsync(cariPage);
        }
    } }