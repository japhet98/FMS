
using FMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
   public class CustomerTransactionController
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
        public List<CustomerWithDept_Result> GetCustomersWithDept(string customerId)
        {
            return db.CustomerWithDept(customerId).ToList();
        }

        //Get All Payments of a Customer
        public List<RetrieveAllCustomerPayments_Result> GetAllCustomerPayments(string customerId)
        {
            return db.RetrieveAllCustomerPayments(customerId).ToList();
        }

        public List<RetrieveCustomerPayments_Result> GetAllCustomerPayments()
        {
            return db.RetrieveCustomerPayments().ToList();
        }


        // Add Customer Payments
        public void AddCustomerPayment(CustomerPaymentDetail payment)
        {
            db.CustomerPaymentDetails.Add(payment);
            db.SaveChanges();
        }

        // Get All Orders 
        public List<FishOrderDetail> GetAllCustomerOrder()
        {
           
            return db.FishOrderDetails.ToList();
        }
    }
}
