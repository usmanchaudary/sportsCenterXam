using sportCenter.Models;
using sportCenter.Repositories.UserRepository;
using sportsCenter.Enums;
using sportsCenter.Models;
using sportsCenterXam.Repositories.VisitiRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sportsCenterXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public static List<string> activityEnums = typeof(ActivityEnum).GetFields().Select(x => x.Name).ToList();
        public ActivityPage()
        {
            InitializeComponent();
            activities.ItemsSource = activityEnums;
            users.ItemsSource = GetUsers().Result.ToList();
        }
        private async Task<List<User>> GetUsers()
        {
            UserService userService = new UserService();
            var users = await userService.GetUsersAsync();
            return users;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            //if user is not selected then show alert
            if (users.SelectedItem == null)
            {
                DisplayAlert("Error", "Please select user", "OK");
                return;
            }
            //if date is not selected then show alert
            if (visitDate.Date == null)
            {
                DisplayAlert("Error", "Please select date", "OK");
                return;
            }
            //if activity is not selected then show alert
            if (activities.SelectedItem == null)
            {
                DisplayAlert("Error", "Please select activity", "OK");
                return;
            }
            var visitRepository = new VisitService();
            var visit = new Visit
            {
                Id = Guid.NewGuid(),
                UserId = ((User)users.SelectedItem).UserCode,
                ActivityEnum = (ActivityEnum)Enum.Parse(typeof(ActivityEnum), activities.SelectedItem.ToString()),
                ActivityDate = visitDate.Date
            };
            visitRepository.AddVisit(visit);
            await DisplayAlert("Success", "Visit added", "OK");
            //navigate to main page
            Navigation.PushModalAsync(new MainPage());
        }
    }
}