
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
   public class CeoController
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

        public void DeleteCeo(string username)
        {
           var ceo =db.CEOs.FirstOrDefault(ce => ce.username == username);
            if (ceo != null)
            {
                db.Entry(ceo).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("CEO Not found");
            }
        }
        
        public void EditCeo(CEO ceo)
        {
            ceo = db.CEOs.FirstOrDefault(ce => ceo.username == ceo.username);
            if (ceo != null)
            {
                db.Entry(ceo).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("CEO Not found");
            }
        }
    }
}
