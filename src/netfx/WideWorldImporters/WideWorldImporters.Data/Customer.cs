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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Customers1 = new HashSet<Customer>();
            this.CustomerTransactions = new HashSet<CustomerTransaction>();
            this.Invoices = new HashSet<Invoice>();
            this.Invoices1 = new HashSet<Invoice>();
            this.Orders = new HashSet<Order>();
            this.SpecialDeals = new HashSet<SpecialDeal>();
            this.StockItemTransactions = new HashSet<StockItemTransaction>();
        }
    
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int BillToCustomerID { get; set; }
        public int CustomerCategoryID { get; set; }
        public Nullable<int> BuyingGroupID { get; set; }
        public int PrimaryContactPersonID { get; set; }
        public Nullable<int> AlternateContactPersonID { get; set; }
        public int DeliveryMethodID { get; set; }
        public int DeliveryCityID { get; set; }
        public int PostalCityID { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public System.DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
        public string WebsiteURL { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; }
        public System.Data.Spatial.DbGeography DeliveryLocation { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        public virtual Person Person2 { get; set; }
        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual ICollection<Customer> Customers1 { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Invoice> Invoices1 { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
