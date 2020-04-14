using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class CustomerController
    {
        FMSEntities db;
        public CustomerController()
        {
            db = new FMSEntities();
        }

        public void AddCustomer(CustomerDetail customer)
        {
            db.CustomerDetails.Add(customer);
            db.SaveChanges();
        }

        public List<CustomerDetail> GetCustomers()
        {
            return db.CustomerDetails.ToList();
        }

        public List<CustomerDetail> GetCustomers(string customerId)
        {
            return db.CustomerDetails.Where(cust => cust.customerId == customerId).ToList();
        }

        public void EditCustomer(CustomerDetail customer)
        {
            customer = (CustomerDetail)db.CustomerDetails.Where(cust =>
            cust.customerId == customer.customerId);
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCustomer(CustomerDetail customer)
        {
            customer = (CustomerDetail)db.CustomerDetails.Where(cust =>
            cust.customerId == customer.customerId);
            db.Entry(customer).State = EntityState.Deleted;
            db.SaveChanges();
        }

       

        

    }
}
