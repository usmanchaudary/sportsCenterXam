using sportsCenter.Models;
using sportsCenterXam.Repositories.SharedRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sportsCenterXam.Repositories.VisitiRepository
{
    public class VisitService : ContextInitializer
    {
        public VisitService()
        {
            _ = Init();
        }
        public void AddVisit(Visit visit)
        {
            Database.Insert(visit);
        }

        public void DeleteVisit(Visit visit)
        {
            Database.Delete(visit);
        }

        public List<Visit> GetVisits()
        {
            return Database.Table<Visit>().ToList();
        }

        public void UpdateVisit(Visit visit)
        {
            Database.Update(visit);
        }

        //get single visit by id    
        public Visit GetVisitById(Guid id)
        {
            return Database.Table<Visit>().Where(v => v.Id == id).FirstOrDefault();
        }

        //get all the visits of user by userId
        public List<Visit> GetVisitsByUserId(Guid userId)
        {
            if (Database.Table<Visit>().Any())
            {
                var visits = Database.Table<Visit>().Where(v => v.UserId == userId).ToList();
                return visits;
            }
            return Enumerable.Empty<Visit>().ToList();
        }
    }
}
