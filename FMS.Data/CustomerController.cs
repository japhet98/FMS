using FMS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
 public   class CustomerController
    {
        FMSEntities db;
        public List<CustomerDetail> Contacts { get; private set; }
        public CustomerController()
        {
            db = new FMSEntities();
            Contacts = new List<CustomerDetail>();
            for (int i = 0; i < 100; i++)
            {
                var c = new CustomerDetail();
                c.customerId = "first name" + i;
                c.Name = "last name" + i;
                c.Phone = "other name" + i;
                c.Resident = "phone number" + i;
                c.IsActive = true;

                Contacts.Add(c);

            }
        }

        public void AddCustomer(CustomerDetail customer)
        {
            db.CustomerDetails.Add(customer);
            db.SaveChanges();
        }

        public List<CustomerDetail> GetCustomers()
        {
            return db.CustomerDetails.ToList(); 
           // return Contacts;
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
