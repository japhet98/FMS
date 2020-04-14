using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class FishTypeController
    {
        private FMSEntities db;

        public FishTypeController()
        {
            db = new FMSEntities();
        }
        public void AddFishType(FishType fishtype)
        {
            db.FishTypes.Add(fishtype);
            db.SaveChanges();
        }

        public List<FishType> GetAddFishTypes()
        {
            return db.FishTypes.ToList();
        }

        public List<FishType> GetCannoes(string fishtype)
        {
            return db.FishTypes.Where(cust => cust.fishType1 == fishtype).ToList();
        }

        public void EditFishType(FishType fishtype)
        {
            fishtype = (FishType)db.FishTypes.Where(cust =>
            cust.fishType1 == fishtype.fishType1);
            db.Entry(fishtype).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteFishType(FishType fishtype)
        {
            fishtype = (FishType)db.FishTypes.Where(cust =>
           cust.fishType1 == fishtype.fishType1);
            db.Entry(fishtype).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
