//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WideWorldImporters.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            this.SupplierTransactions = new HashSet<SupplierTransaction>();
            this.CustomerTransactions = new HashSet<CustomerTransaction>();
        }
    
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
    }
}
