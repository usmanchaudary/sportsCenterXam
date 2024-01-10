using Microsoft.VisualBasic;
using sportCenter.ApplicationConstants;
using sportCenter.Models;
using sportsCenter.Models;
using sportsCenterXam.Repositories.SharedRepository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportCenter.Repositories.UserRepository
{
    public class UserService : ContextInitializer
    {
        //GetUsersAsync
        public async Task<List<User>> GetUsersAsync()
        {
            await Init();
            var users = Database.Table<User>().ToList();
            return users;
        }
        //GetUserAsync
        public async Task<User> GetUserAsync(Guid userCode)
        {
            await Init();
            return Database.Table<User>().Where(u => u.UserCode == userCode).FirstOrDefault();
        }
        //SaveUserAsync
        public async Task SaveUserAsync(User user)
        {
            await Init();
            if (user.UserCode == Guid.Empty)
            {
                user.UserCode = Guid.NewGuid();
                Database.Insert(user);
                Database.Commit();
            }
            else
            {
                Database.Update(user);
                Database.Commit();
            }
        }
        //DeleteUserAsync
        public async Task DeleteUserAsync(User user)
        {
            await Init();
            Database.Delete(user);
            Database.Commit();

        }
        //updateUserAsync
        public async Task UpdateUserAsync(User user)
        {
            await Init();
            Database.Update(user);
            Database.Commit();

        }
        //GetUsersByGenderAsync
        public async Task<List<User>> GetUsersByGender(string gender)
        {
            await Init();
            return Database.Table<User>().Where(x => x.Gender.ToString() == gender).ToList();
        }
        //GetUsersByMemberAsync
        public async Task<List<User>> GetUsersByMembership(bool isMember)
        {
            await Init();
            var set = Database.Table<User>();
            set = isMember ? set.Where(x => x.IsMember) : set.Where(x => !x.IsMember);
            return set.ToList();
        }

        ~UserService()
        {
            Database?.Close();
        }
    }
}
