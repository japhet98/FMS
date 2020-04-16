
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace FMS.Repository
{
    public   class CustomerController
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
           
            return db.CustomerDetails.Where(cust => cust.Name == customerId).ToList();
        }

        public void EditCustomer(CustomerDetail customer)
        {
            customer =db.CustomerDetails.FirstOrDefault(cust =>
            cust.customerId == customer.customerId);
            if(customer != null)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Customer Does not Exit");
            }
           
        }

        public void DeleteCustomer(string customerId)
        {
          var  customer=db.CustomerDetails.FirstOrDefault(cust =>
            cust.customerId == customerId);
            if (customer != null)
            {
                db.Entry(customer).State = EntityState.Deleted;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Customer Does not Exit");
            }
        }

       

        

    }
}
