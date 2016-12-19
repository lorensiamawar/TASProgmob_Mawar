using System;
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
    public class BarangViewModel : BindableObject
    {
        private RestClient _client =
            new RestClient("http://mawar.azurewebsites.net/");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/Barang", Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }

        public BarangViewModel()
        {
            RefreshDataAsync();
        }
    }
}
