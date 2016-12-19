using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XamarinClientApp.ViewModel;
using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinClientApp
{
    public partial class CariKategoriPage : ContentPage
    {
        public CariKategoriPage()
        {
            InitializeComponent();
            btnSearch.Clicked += BtnSearch_Clicked;
            listKategori.ItemTapped += ListKategori_ItemTapped;
        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {
            if (switcer.IsToggled.ToString() == "True")
            {
                this.BindingContext = new CariKategori(txtSearch.Text);
            if (switcer.IsToggled.ToString() == "False")
            {
                this.BindingContext = new CariBarangVM(txtSearch.Text, switcer.IsToggled.ToString());
                }
            }
        }

        private void ListKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CariKategori item = (CariKategori)e.Item;
            EditKategoriPage editPage = new EditKategoriPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
