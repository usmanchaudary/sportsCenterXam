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
        public static List<string> activityEnums = typeof(ActivityEnum).GetProperties().Select(x => x.Name).ToList();
        public ActivityPage()
        {
            InitializeComponent();
            users.ItemsSource = new List<User>();
            users.ItemsSource = GetUsers().Result.ToList();
        }
        private async Task<List<User>> GetUsers()
        {
            UserService userService = new UserService();
            var users = await userService.GetUsersAsync();
            return users;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            var visitRepository = new VisitService();
            var visit = new Visit
            {
                Id = Guid.NewGuid(),
                UserId = ((User)users.SelectedItem).UserCode,
                ActivityEnum = (ActivityEnum)Enum.Parse(typeof(ActivityEnum), activities.SelectedItem.ToString()),
                ActivityDate = visitDate.Date
            };
            visitRepository.AddVisit(visit);
            DisplayAlert("Success", "Visit added", "OK");
            //navigate to main page
            Navigation.PushModalAsync(new MainPage());
        }
    }
}