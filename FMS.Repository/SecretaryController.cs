
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
  public  class SecretaryController
    {
        FMSEntities _db;
        public SecretaryController()
        {
            _db = new FMSEntities();
        }

        public void AddSecretary(Secretary sec)
        {
            _db.Secretaries.Add(sec);
            _db.SaveChanges();
        }

        public void UpdateSecretary(Secretary sec)
        {
            sec = _db.Secretaries.FirstOrDefault(cust => cust.SecretaryId == sec.SecretaryId);
            _db.Entry(sec).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteSecretary(Secretary sec)
        {
            sec = _db.Secretaries.FirstOrDefault(cust => cust.SecretaryId == sec.SecretaryId);
            if (sec != null)
            {
                _db.Entry(sec).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Secretary Id cannot be found");
            }
        }

        public Secretary GetSecretaries(int SecretaryId)
        {
            return _db.Secretaries.FirstOrDefault(cust => cust.SecretaryId == SecretaryId);
        }
        public List<Secretary> GetSecretaries()
        {
            return _db.Secretaries.ToList();
        }

    }
}
