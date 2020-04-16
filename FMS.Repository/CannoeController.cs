
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
  public  class CannoeController
    {
        private FMSEntities db;

        public CannoeController()
        {
            db = new FMSEntities();
        }
        public void AddCannoe(CannoeDetail cannoe)
        {
            db.CannoeDetails.Add(cannoe);
            db.SaveChanges();
        }

        public List<CannoeDetail> GetCannoes()
        {
            return db.CannoeDetails.ToList();
        }

        public CannoeDetail GetCannoes(string cannoetype)
        {
            return db.CannoeDetails.FirstOrDefault(cust => cust.cannoeType == cannoetype);
        }

        public void EditCannoe(CannoeDetail cannoe)
        {
            cannoe = db.CannoeDetails.FirstOrDefault(cust =>
            cust.cannoeType == cannoe.cannoeType);
            if (cannoe != null)
            {
                db.Entry(cannoe).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannoe Not found");
            }
        }

        public void DeleteCannoe(CannoeDetail cannoe)
        {
            cannoe = db.CannoeDetails.FirstOrDefault(cust =>
            cust.cannoeType == cannoe.cannoeType);
            if (cannoe != null)
            {
                db.Entry(cannoe).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannoe Not found");
            }
        }

    }
}
