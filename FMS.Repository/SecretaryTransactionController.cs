
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
   public class SecretaryTransactionController
    {
        private FMSEntities _db;

        public SecretaryTransactionController()
        {
            _db = new FMSEntities();
        }
        public void AddSecretaryPayment(SecretaryPayment payment)
        {
            _db.SecretaryPayments.Add(payment);
            _db.SaveChanges();
        }


        public void UpdateSecretaryPayment(SecretaryPayment payment)
        {
            payment = _db.SecretaryPayments.FirstOrDefault(cust => cust.SecretaryPaymentId == payment.SecretaryPaymentId);
            _db.Entry(payment).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteSecretaryPayment(SecretaryPayment payment)
        {
            payment = _db.SecretaryPayments.FirstOrDefault(cust => cust.SecretaryPaymentId == payment.SecretaryPaymentId);
            if (payment != null)
            {
                _db.Entry(payment).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("SecretaryPayment Id cannot be found");
            }
        }

        public SecretaryPayment GetSecretaryPayments(int SecretaryPaymentId)
        {
            return _db.SecretaryPayments.FirstOrDefault(cust => cust.SecretaryPaymentId == SecretaryPaymentId);
        }
        public List<SecretaryPayment> GetSecretaryPayments()
        {
            return _db.SecretaryPayments.ToList();
        }
    }
}

