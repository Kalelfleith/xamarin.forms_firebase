using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_firebaseApp.Services;

namespace XF_firebaseApp
{
    public partial class MainPage : ContentPage
    {

        FirebaseService fbService = new FirebaseService();

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var users = await fbService.GetUsers();
            listUsers.ItemsSource = users;
        }

        private async void BtnAdd_Clicked(object sender, System.EventArgs e)
        {
            
        }
        private void BtnDisplay_Clicked(object sender, System.EventArgs e)
        { }
        private void BtnDelete_Clicked(object sender, System.EventArgs e)
        { }
        private void BtnUpdate_Clicked(object sender, System.EventArgs e)
        { }
    }
}
