
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
  public  class FishTypeController
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

        public FishType GetAddFishTypes(string fishtype)
        {
            return db.FishTypes.FirstOrDefault(cust => cust.fishType1 == fishtype);
        }

        public void EditFishType(FishType fishtype)
        {
            fishtype = db.FishTypes.FirstOrDefault(cust =>
            cust.fishType1 == fishtype.fishType1);
            if(fishtype != null)
            {
                db.Entry(fishtype).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Fish Type Not found");
            }
           
        }

        public void DeleteFishType(FishType fishtype)
        {
            fishtype = db.FishTypes.FirstOrDefault(cust =>
           cust.fishType1 == fishtype.fishType1);
            if (fishtype != null)
            {
                db.Entry(fishtype).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Fish Type Not found");
            }
        }
    }
}
