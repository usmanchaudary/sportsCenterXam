using sportCenter.Repositories.UserRepository;
using sportsCenter.Models;
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
    public partial class UserDetails : ContentPage
    {
        ObservableCollection<Visit> visits = new ObservableCollection<Visit>();
        public UserDetails()
        {
            InitializeComponent();
            BindingContext = App.UserViewModel;
            visits = new ObservableCollection<Visit>(App.UserViewModel.Visits);
            userVisits.ItemsSource = visits;
        }

        private async void UpdateMembership_Click(object sender, EventArgs e)
        {
            // Get the chkIsMember value
            var isMember = chkIsMember.IsChecked;

            // Get the classId value of isMember
            var userCode = chkIsMember.ClassId;

            // Create a UserService instance
            var userService = new UserService();

            // Get the user by userCode
            var user = await userService.GetUserAsync(Guid.Parse(userCode));

            // Update the user's membership status
            user.IsMember = isMember;

            // Save the updated user
            await userService.SaveUserAsync(user);

            // Update the SelectedUser in the UserViewModel
            App.UserViewModel.SelectedUser = user;

            // Display a success message
            await DisplayAlert("Success", "User membership updated", "OK");

            // Navigate back to the previous page
            await Navigation.PopModalAsync();
        }
    }
}