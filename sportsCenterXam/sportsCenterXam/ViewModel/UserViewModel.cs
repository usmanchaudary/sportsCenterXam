using sportCenter.Models;
using sportsCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportCenter.ViewModel
{
    /// <summary>
    /// Represents the view model for the User entity.
    /// </summary>
    public class UserViewModel : INotifyPropertyChanged
    {
        private User _selectedUser;
        private List<Visit> _userVisits;

        /// <summary>
        /// Gets or sets the selected user.
        /// </summary>
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }

        /// <summary>
        /// Gets or sets the list of visits for the user.
        /// </summary>
        public List<Visit> Visits
        {
            get { return _userVisits; }
            set
            {
                if (_userVisits != value)
                {
                    _userVisits = value;
                    OnPropertyChanged(nameof(Visits));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}