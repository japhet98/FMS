using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class SalerTransactionController
    {
        FMSEntities _db;

        public SalerTransactionController()
        {
            _db = new FMSEntities();
        }

        public void AddSalerPayment(SalerPayment payment)
        {
            _db.SalerPayments.Add(payment);
            _db.SaveChanges();
        }


        public void UpdateSalerPayment(SalerPayment payment)
        {
            payment = _db.SalerPayments.FirstOrDefault(cust => cust.SalerPaymentId == payment.SalerPaymentId);
            _db.Entry(payment).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteSalerPayment(SalerPayment payment)
        {
            payment = _db.SalerPayments.FirstOrDefault(cust => cust.SalerPaymentId == payment.SalerPaymentId);
            if (payment != null)
            {
                _db.Entry(payment).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("SalerPayment Id cannot be found");
            }
        }

        public SalerPayment GetSalerPayments(int SalerPaymentId)
        {
            return _db.SalerPayments.FirstOrDefault(cust => cust.SalerPaymentId == SalerPaymentId);
        }
        public List<SalerPayment> GetSalerPayments()
        {
            return _db.SalerPayments.ToList();
        }
    }
}
