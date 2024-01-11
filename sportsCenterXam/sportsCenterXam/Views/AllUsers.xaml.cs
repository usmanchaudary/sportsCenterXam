using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
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

        private async void OnDelete(User user)
        {
            var userService = new UserService();
            await userService.DeleteUserAsync(user);
            usersList.ItemsSource = await GetUsers();
        }

        private void OnDetails(User user)
        {
            throw new NotImplementedException();
        }

        public AllUsers()
        {
            InitializeComponent();
            GetUsers().ContinueWith(t =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //add users to the observable collection
                    foreach (var user in t.Result)
                    {
                        users.Add(user);
                    }
                });
                usersList.ItemsSource = users;
            });
        }
        private async Task<List<User>> GetUsers()
        {
            var userService = new UserService();
            return await userService.GetUsersAsync();
        }
    }
}