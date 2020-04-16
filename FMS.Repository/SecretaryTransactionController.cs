
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
   public class SecretaryTransactionController
    {
        private FMSEntities db;

        public SecretaryTransactionController()
        {
            db = new FMSEntities();
        }

        //Pay Secretary
        public void AddSecretaryPayment(SecretaryPaymentDetail payment)
        {
            db.SecretaryPaymentDetails.Add(payment);
            db.SaveChanges();
        }

        // Get Paid Secretaries
        public List<SecretaryPaymentDetail> GetAllPaidSecretary()
        {
            return db.SecretaryPaymentDetails.ToList();
        }
        public SecretaryPaymentDetail GetAllPaidSecretary(string name)
        {
            return db.SecretaryPaymentDetails.FirstOrDefault(sec => sec.secretaryName == name);
        }
    }
}
