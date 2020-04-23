
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
        FMSEntities _db;

        public CeoController()
        {
            _db = new FMSEntities();
        }
        public void AddCEO(CEO ceo)
        {
            _db.CEOs.Add(ceo);
            _db.SaveChanges();
        }

        public void UpdateCEO(CEO ceo)
        {
            ceo = _db.CEOs.FirstOrDefault(cust => cust.CeoId == ceo.CeoId);
            _db.Entry(ceo).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCEO(CEO ceo)
        {
            ceo = _db.CEOs.FirstOrDefault(cust => cust.CeoId == ceo.CeoId);
            if (ceo != null)
            {
                _db.Entry(ceo).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("CEO Id cannot be found");
            }
        }

        public CEO GetCEOs(int ceoId)
        {
            return _db.CEOs.FirstOrDefault(cust => cust.CeoId == ceoId);
        }
        public List<CEO> GetCEOs()
        {
            return _db.CEOs.ToList();
        }


    }
}
