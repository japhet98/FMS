
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace FMS.Repository
{
    public   class CustomerController
    {
        FMSEntities _db;
     
        public CustomerController()
        {
            _db = new FMSEntities();
           
        }
        public void AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            customer = _db.Customers.FirstOrDefault(cust => cust.customerId == customer.customerId);
            _db.Entry(customer).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            customer = _db.Customers.FirstOrDefault(cust => cust.customerId == customer.customerId);
            if (customer != null)
            {
                _db.Entry(customer).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Customer Id cannot be found");
            }
        }

        public Customer GetCustomers(int CusttomerId)
        {
            return _db.Customers.FirstOrDefault(cust => cust.customerId == CusttomerId);
        }
        public List<Customer> GetCustomers()
        {
            return _db.Customers.ToList();
        }


    }
}
