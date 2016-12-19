﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using TASProgmob_Mawar.Model;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace TASProgmob_Mawar
{
    public partial class TambahKategoriPage : ContentPage
    {
        public TambahKategoriPage()
        {
            InitializeComponent();
            btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
        }
        private RestClient _client =
            new RestClient("http://mawar.azurewebsites.net/");

        private async void BtnTambahKategori_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Kategori", Method.POST);
            var newKategori = new Kategori { NamaKategori = txtNamaKategori.Text };
            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new KategoriPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
