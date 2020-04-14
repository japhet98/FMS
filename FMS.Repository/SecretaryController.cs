using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class SecretaryController
    {
        FMSEntities db;
        public SecretaryController()
        {
            db = new FMSEntities();
        }

        public void AddSecretary(SecretaryDetail secretary)
        {
            db.SecretaryDetails.Add(secretary);
            db.SaveChanges();
        }
         
        public void EditSecretary(SecretaryDetail secretary)
        {
            secretary = (SecretaryDetail)db.SecretaryDetails.Where(sec =>
           sec.Name == secretary.Name);
            db.Entry(secretary).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSecretary(SecretaryDetail secretary)
        {
            secretary = (SecretaryDetail)db.SecretaryDetails.Where(sec =>
           sec.Name == secretary.Name);
            db.Entry(secretary).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<SecretaryDetail> GetSecretarys()
        {
            return db.SecretaryDetails.ToList();
        }

        public List<SecretaryDetail> GetSecretarys(string name)
        {
            return db.SecretaryDetails.Where(sec => sec.Name == name).ToList();
        }
    }
}
