using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using XamarinClientApp.ViewModel;
using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace XamarinClientApp
{
    public partial class CariItemPage : ContentPage
    {
        public CariItemPage()
        {
            InitializeComponent();
            btnSearch.Clicked += BtnSearch_Clicked;
            listBarang.ItemTapped += ListBarang_ItemTapped;
        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {
            if (switcer.IsToggled.ToString() == "True")
            {
                this.BindingContext = new CariBarangVM(txtSearch.Text, switcer.IsToggled.ToString());
            }
            if (switcer.IsToggled.ToString() == "False")
            {
                this.BindingContext = new CariKategori(txtSearch.Text);
            }
        }

        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CariBarangVM item = (CariBarangVM)e.Item;
            EditBarangPage editPage = new EditBarangPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
