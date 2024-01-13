using sportCenter.Enums;
using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUser : ContentPage
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the RegisterUser button click.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void RegisterUser_Clicked(object sender, EventArgs e)
        {
            var userService = new UserService();
            Enum.TryParse<UserGender>(userGender?.SelectedItem?.ToString(), out UserGender result);

            // Create a new User object with input values
            var user = new User
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                DateOfBirth = dateofBirth.Date,
                Gender = result,
                IsMember = isMember.IsToggled
            };

            // Save the new user to the data store
            await userService.SaveUserAsync(user);

            // Display a success message to the user
            await DisplayAlert("Success", "User registered", "OK");
            await Navigation.PopModalAsync();
        }
    }
}