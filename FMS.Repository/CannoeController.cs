
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    public class CannoeController
    {
        private FMSEntities _db;

        public CannoeController()
        {
            _db = new FMSEntities();
        }

        public void AddCannoe(Cannoe cannoe)
        {
            _db.Cannoes.Add(cannoe);
            _db.SaveChanges();
        }

        public void UpdateCannoe(Cannoe cannoe)
        {
            cannoe = _db.Cannoes.FirstOrDefault(cust => cust.CannoeId == cannoe.CannoeId);
            _db.Entry(cannoe).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCannoe(Cannoe cannoe)
        {
            cannoe = _db.Cannoes.FirstOrDefault(cust => cust.CannoeId == cannoe.CannoeId);
            if (cannoe != null)
            {
                _db.Entry(cannoe).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Cannoe Id cannot be found");
            }
        }

        public Cannoe GetCannoes(int CannoeId)
        {
            return _db.Cannoes.FirstOrDefault(cust => cust.CannoeId == CannoeId);
        }
        public List<Cannoe> GetCannoes()
        {
            return _db.Cannoes.ToList();
        }


    }
}
