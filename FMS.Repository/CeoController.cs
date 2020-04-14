using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class CeoController
    {
        FMSEntities db;

        public CeoController()
        {
            db = new FMSEntities();
        }

        public void AddCeo(CEO ceo)
        {
            db.CEOs.Add(ceo);
            db.SaveChanges();
        }

        public List<CEO> GetCeo()
        {
            return db.CEOs.ToList();
        }

        public void DeleteCeo(CEO ceo)
        {
            ceo = (CEO)db.CEOs.Where(ce => ce.username == ceo.username);
            db.Entry(ceo).State = EntityState.Deleted;
            db.SaveChanges();
        }
        
        public void EditCeo(CEO ceo)
        {
            ceo = (CEO)db.CEOs.Where(ce => ceo.username == ceo.username);
            db.Entry(ceo).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
