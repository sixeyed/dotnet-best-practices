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
    
    public partial class StockGroup
    {
        public StockGroup()
        {
            this.SpecialDeals = new HashSet<SpecialDeal>();
            this.StockItemStockGroups = new HashSet<StockItemStockGroup>();
        }
    
        public int StockGroupID { get; set; }
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
    }
}
