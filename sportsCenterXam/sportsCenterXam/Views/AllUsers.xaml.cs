using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using sportsCenterXam.Repositories.VisitiRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllUsers : ContentPage
    {
        //create an observable collection of users
        ObservableCollection<User> users = new ObservableCollection<User>();
        public ICommand DetailsCommand => new Command<User>(OnDetails);
        public ICommand DeleteCommand => new Command<User>(OnDelete);
        private readonly UserService userService = new UserService();


        private async void OnDelete(User user)
        {
            var userService = new UserService();
            await userService.DeleteUserAsync(user);
            cvUsers.ItemsSource = await GetUsers();
            await DisplayAlert("Success", "User deleted", "OK");
        }

        private async void OnDetails(User user)
        {
            App.UserViewModel.SelectedUser = user;
            var visitService = new VisitService();
            App.UserViewModel.Visits = visitService.GetVisitsByUserId(user.UserCode);
            await Navigation.PushModalAsync(new UserDetails());
        }

        public AllUsers()
        {
            InitializeComponent();
            InitializeDataSource();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeDataSource();
        }

        /// <summary>
        /// Initializes the data source for the users.
        /// </summary>
        private void InitializeDataSource()
        {
            var updatedUsers = userService.GetUsersAsync().Result;
            users = new ObservableCollection<User>(updatedUsers);
            cvUsers.ItemsSource = users;
        }
        private async Task<List<User>> GetUsers()
        {
            
            return await userService.GetUsersAsync();
        }
    }
}