﻿using System;
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
    public partial class EditJenisMotorPage : ContentPage
    {
        public EditJenisMotorPage()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;

        }
        private RestClient _client =
        new RestClient("http://mawar.azurewebsites.net/");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);

            _request.AddParameter("id", txtIdJenisMotor.Text);
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

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.PUT);
            var newJenisMotor = new JenisMotor
            {
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                NamaMerk = txtNamaMerk.Text,
                NamaJenisMotor = txtNamaJenis.Text

            };

            _request.AddBody(newJenisMotor);
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
