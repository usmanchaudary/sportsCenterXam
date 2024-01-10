using sportsCenter.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsCenter.Models
{
    public class Visit
    {
        public Visit()
        {
           Id = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public Guid UserId { get; set; }
        public ActivityEnum ActivityEnum { get; set; }

    }
}
