using FMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    class CustomerTransactionController
    {
        FMSEntities db;
        public CustomerTransactionController()
        {
            db = new FMSEntities();
        }

        // Create New Customer Order
        public void AddCustomerOrder(FishOrderDetail order)
        {
            db.FishOrderDetails.Add(order);
            db.SaveChanges();
        }


        // Get all customers and their dept
        public List<CustomersWithDept> GetCustomersWithDept()
        {
            return db.CustomersWithDepts.ToList();
        }

        // Get Specific customer and his dept
        public List<CustomerWithDept_Result> GetCustomersWithDept(CustomerDetail customer)
        {
            return db.CustomerWithDept(customer.customerId).ToList();
        }

        //Get All Payments of a Customer
        public List<RetrieveAllCustomerPayments_Result> GetAllCustomerPayments(string customerId)
        {
            return db.RetrieveAllCustomerPayments(customerId).ToList();
        }

        // Add Customer Payments
        public void AddCustomerPayment(CustomerPaymentDetail payment)
        {
            db.CustomerPaymentDetails.Add(payment);
            db.SaveChanges();
        }
    }
}
