using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class CannoeController
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

        public List<CannoeDetail> GetCannoes(string cannoetype)
        {
            return db.CannoeDetails.Where(cust => cust.cannoeType == cannoetype).ToList();
        }

        public void EditCannoe(CannoeDetail cannoe)
        {
            cannoe = (CannoeDetail)db.CannoeDetails.Where(cust =>
            cust.cannoeType == cannoe.cannoeType);
            db.Entry(cannoe).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCannoe(CannoeDetail cannoe)
        {
            cannoe = (CannoeDetail)db.CannoeDetails.Where(cust =>
            cust.cannoeType == cannoe.cannoeType);
            db.Entry(cannoe).State = EntityState.Deleted;
            db.SaveChanges();
        }

    }
}
