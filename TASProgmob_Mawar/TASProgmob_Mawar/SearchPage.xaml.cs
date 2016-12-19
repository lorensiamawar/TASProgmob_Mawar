using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASProgmob_Mawar.Model;
using TASProgmob_Mawar.ViewModel;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Xamarin.Forms;

namespace TASProgmob_Mawar
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            btnCariBarang.Clicked += BtnCariBarang_Clicked;
            btnCariKategori.Clicked += BtnCariKategori_Clicked;
        }

        private void BtnCariKategori_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchKategori(txtCariKategori.Text);

            txtCariKategori.Text = null;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new SearchKategori("");
        }

        private void BtnCariBarang_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchBarang(txtCariBarang.Text);
            
            txtCariBarang.Text = null;

        }

    }
}
