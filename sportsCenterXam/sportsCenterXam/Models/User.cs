using sportCenter.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportCenter.Models
{
    public class User
    {

        [PrimaryKey]
        public Guid UserCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime DateOfBirth { get; set; }
        public bool IsMember { get; set; }
        public UserGender Gender { get; set; }
    }
}