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
    using System.Collections.Generic;
    
    public partial class SalerPayment
    {
        public int SalerPaymentId { get; set; }
        public string SalerName { get; set; }
        public Nullable<int> DaysWorked { get; set; }
        public string SalerSignature { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime DatePaid { get; set; }
    }
}
