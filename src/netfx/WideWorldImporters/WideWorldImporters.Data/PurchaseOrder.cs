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
    
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            this.SupplierTransactions = new HashSet<SupplierTransaction>();
            this.StockItemTransactions = new HashSet<StockItemTransaction>();
        }
    
        public int PurchaseOrderID { get; set; }
        public int SupplierID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int DeliveryMethodID { get; set; }
        public int ContactPersonID { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public string SupplierReference { get; set; }
        public bool IsOrderFinalized { get; set; }
        public string Comments { get; set; }
        public string InternalComments { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime LastEditedWhen { get; set; }
    
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
