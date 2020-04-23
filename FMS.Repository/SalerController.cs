using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class SalersController
    {
        FMSEntities _db;


        public SalersController()
        {
            _db = new FMSEntities();
        }

        public void AddSalers(Saler saler)
        {
            _db.Salers.Add(saler);
            _db.SaveChanges();
        }

        public void UpdateSalers(Saler saler)
        {
            saler = _db.Salers.FirstOrDefault(cust => cust.SalerId == saler.SalerId);
            _db.Entry(saler).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteSalers(Saler saler)
        {
            saler = _db.Salers.FirstOrDefault(cust => cust.SalerId == saler.SalerId);
            if (saler != null)
            {
                _db.Entry(saler).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Saler Id cannot be found");
            }
        }

        public Saler GetSalers(int SalerId)
        {
            return _db.Salers.FirstOrDefault(cust => cust.SalerId == SalerId);
        }
        public List<Saler> GetSaler()
        {
            return _db.Salers.ToList();
        }
    }
}
