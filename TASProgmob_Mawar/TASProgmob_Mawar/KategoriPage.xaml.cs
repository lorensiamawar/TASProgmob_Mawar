using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using TASProgmob_Mawar.Model;
using TASProgmob_Mawar.ViewModel;
namespace TASProgmob_Mawar
{
    public partial class KategoriPage : ContentPage
    {
        public KategoriPage()
        {
            InitializeComponent();
            listKategori.ItemTapped += ListKategori_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
            btnCari.Clicked += BtnCari_Clicked;
        }
        private async void BtnCari_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TambahKategoriPage());
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
    }
}
