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
    
    public partial class PackageType
    {
        public PackageType()
        {
            this.PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.OrderLines = new HashSet<OrderLine>();
            this.StockItems = new HashSet<StockItem>();
            this.StockItems1 = new HashSet<StockItem>();
        }
    
        public int PackageTypeID { get; set; }
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<StockItem> StockItems1 { get; set; }
    }
}