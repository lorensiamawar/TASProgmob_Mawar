using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASProgmob_Mawar.Model;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using Xamarin.Forms;

namespace TASProgmob_Mawar
{
    public partial class EditBarangPage : ContentPage
    {
        public EditBarangPage()
        {
            InitializeComponent();
            btnDelete.Clicked += BtnDelete_Clicked;
            btnEdit.Clicked += BtnEdit_Clicked;
        }
        private RestClient _client =
        new RestClient("http://mawar.azurewebsites.net/");
        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.PUT);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                Nama = txtNama.Text,
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                Stok = Convert.ToInt32(txtStok.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaJual.Text),
                TanggalBeli = txtTanggalBeli.Date


            };

            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang/{id}", Method.DELETE);

            _request.AddParameter("id", txtKodeBarang.Text);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
