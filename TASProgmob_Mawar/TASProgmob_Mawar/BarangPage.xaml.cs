using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASProgmob_Mawar.Model;
using TASProgmob_Mawar.ViewModel;
using Xamarin.Forms;

namespace TASProgmob_Mawar
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
        private async void BtnCari_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahBarangPage());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }
        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            EditBarangPage editPage = new EditBarangPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
