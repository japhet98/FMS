//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FMS.Model
{
    using System;
    
    public partial class RetrieveCustomerPayments_Result
    {
        public string Customer_Name { get; set; }
        public string Fish_Type { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount_Paid { get; set; }
        public string Reciever_Name { get; set; }
        public System.DateTime Date_Ordered { get; set; }
        public System.DateTime Date_Received { get; set; }
    }
}
