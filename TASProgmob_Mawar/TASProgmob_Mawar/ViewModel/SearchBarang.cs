﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASProgmob_Mawar.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace TASProgmob_Mawar.ViewModel
{
    public class SearchBarang : BindableObject
    {
        private RestClient _client =
            new RestClient("http://mawar.azurewebsites.net/");

        private ObservableCollection<Barang> listBarangVM;
        public ObservableCollection<Barang> ListBarangVM
        {
            get { return listBarangVM; }
            set { listBarangVM = value; OnPropertyChanged("ListBarangVM"); }
        }


        private async void RefreshDataAsync(string Nama)
        {
            RestRequest _request = new RestRequest("api/barang/?namaBarang=" + Nama, Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarangVM = new ObservableCollection<Barang>(_response.Data);
        }

        public SearchBarang(string Nama)
        {
            RefreshDataAsync(Nama);
        }
    }
}
