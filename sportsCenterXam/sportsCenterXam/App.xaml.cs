using sportCenter.Models;
using sportCenter.ViewModel;
using sportsCenter.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam
{
    public partial class App : Application
    {

        public static UserViewModel UserViewModel { get; set; } = new UserViewModel()
        {
            SelectedUser = new User(),
            Visits = new List<Visit>()
        };

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
