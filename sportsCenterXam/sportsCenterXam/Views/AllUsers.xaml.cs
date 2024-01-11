using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllUsers : ContentPage
    {
        //create an observable collection of users
        ObservableCollection<User> users = new ObservableCollection<User>();
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
            });
        }
        private async Task<List<User>> GetUsers()
        {
            var userService = new UserService();
            return await userService.GetUsersAsync();
        }
    }
}