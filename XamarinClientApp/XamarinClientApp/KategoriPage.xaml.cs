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
    public partial class KategoriPage : ContentPage
    {
        public KategoriPage()
        {
            InitializeComponent();
            btnTambah.Clicked += btnTambahKategori_Clicked;
            listKategori.ItemTapped += ListKategori_ItemTapped;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }

        private void ListKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Kategori item = (Kategori)e.Item;
            EditKategoriPage editPage = new EditKategoriPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void btnTambahKategori_Clicked(object sender, EventArgs e)
        {
            TambahKategoriPage tambahPage = new TambahKategoriPage();
            Navigation.PushAsync(tambahPage);
        }

        private async void BtnCari_Clicked(object sender, EventArgs e)
        {
            CariKategoriPage cariPage = new CariKategoriPage();
            Navigation.PushAsync(cariPage);
        }
    }
}