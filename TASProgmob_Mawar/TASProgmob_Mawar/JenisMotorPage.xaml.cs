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
    public partial class JenisMotorPage : ContentPage
    {
        public JenisMotorPage()
        {
            InitializeComponent();
            listJenis.ItemTapped += ListJenis_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
        }
        private async void BtnTambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JenisMotorPage());
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new JenisMotorViewModel();
        }
        private void ListJenis_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            EditJenisMotorPage editPage = new EditJenisMotorPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }
    }
}
