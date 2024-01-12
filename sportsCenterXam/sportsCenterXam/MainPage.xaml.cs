using sportsCenterXam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sportsCenterXam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            //navigate to register page
            Navigation.PushModalAsync(new RegisterUser());
        }

        private void CreateActivity_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ActivityPage());
        }

        private void ShowUsersBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AllUsers());
        }
    }
}
