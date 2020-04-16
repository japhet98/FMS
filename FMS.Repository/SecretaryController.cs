
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
            secretary = db.SecretaryDetails.FirstOrDefault(sec =>
           sec.Name == secretary.Name);
            if (secretary != null)
            {
                db.Entry(secretary).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Sec Not found");
            }
        }

        public void DeleteSecretary(string secName)
        {
            var secretary = db.SecretaryDetails.FirstOrDefault(sec =>
           sec.Name == secName);
            if (secretary != null)
            {
                db.Entry(secretary).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else{
                throw new Exception("Sec Not found");
            }

          
        }

        public List<SecretaryDetail> GetSecretarys()
        {
            return db.SecretaryDetails.ToList();
        }

        public SecretaryDetail GetSecretarys(string name)
        {
            return db.SecretaryDetails.FirstOrDefault(sec => sec.Name == name);
        }
    }
}
