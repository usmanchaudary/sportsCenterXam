using sportCenter.Models;
using sportCenter.ViewModel;
using sportsCenter.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam
{
    /// <summary>
    /// Represents the main application class responsible for initializing the application and managing global resources.
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Gets or sets the instance of the UserViewModel used for managing user-related data and state.
        /// </summary>
        public static UserViewModel UserViewModel { get; set; } = new UserViewModel()
        {
            SelectedUser = new User(),
            Visits = new List<Visit>()
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
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
