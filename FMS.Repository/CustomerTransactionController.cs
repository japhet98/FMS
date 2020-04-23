
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
   public class CustomerTransactionController
    {

        /*
        Add Customer Payment
        View Customer Payment
        Edit Customer payment
        remove Customer Payment

         */
        private FMSEntities _db;

        public CustomerTransactionController()
        {
            _db = new FMSEntities();
        }

        public void AddCustomerPayment(CustomerPayment payment)
        {
            _db.CustomerPayments.Add(payment);
            _db.SaveChanges();
        }

        public void UpdateCustomerPayment(CustomerPayment payment)
        {
            payment = _db.CustomerPayments.FirstOrDefault(cust => cust.customerPaymentId == payment.customerPaymentId);
            _db.Entry(payment).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCustomerPayment(CustomerPayment payment)
        {
            payment = _db.CustomerPayments.FirstOrDefault(cust => cust.customerPaymentId == payment.customerPaymentId);
            if (payment != null)
            {
                _db.Entry(payment).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("CustomerPayment Id cannot be found");
            }
        }

        public CustomerPayment GetCustomerPayments(int CustomerPaymentId)
        {
            return _db.CustomerPayments.FirstOrDefault(cust => cust.customerPaymentId == CustomerPaymentId);
        }
        public List<CustomerPayment> GetCustomerPayments()
        {
            return _db.CustomerPayments.ToList();
        }
    }
}
