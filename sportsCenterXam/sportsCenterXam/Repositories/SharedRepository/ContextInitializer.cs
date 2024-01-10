using sportCenter.ApplicationConstants;
using sportCenter.Models;
using sportsCenter.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sportsCenterXam.Repositories.SharedRepository
{
    public class ContextInitializer
    {
        protected SQLiteConnection Database;
        public async Task Init()
        {
            if (Database != null)
                return;

            Database = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            Database.CreateTable<User>();
            Database.CreateTable<Visit>();
        }
    }
}
