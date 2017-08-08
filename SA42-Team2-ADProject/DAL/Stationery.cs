//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stationery
    {
        public Stationery()
        {
            this.AdjustmentVoucherDetails = new HashSet<AdjustmentVoucherDetail>();
            this.DisbursementListDetails = new HashSet<DisbursementListDetail>();
            this.PurchasingOrderDetails = new HashSet<PurchasingOrderDetail>();
            this.Reminders = new HashSet<Reminder>();
            this.RequisitionDetails = new HashSet<RequisitionDetail>();
            this.StationeryTransactions = new HashSet<StationeryTransaction>();
        }
    
        public string StationeryId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public int UOMId { get; set; }
        public string Bin { get; set; }
        public string Supplier1 { get; set; }
        public string Supplier2 { get; set; }
        public string Supplier3 { get; set; }
        public Nullable<decimal> Price1 { get; set; }
        public Nullable<decimal> Price2 { get; set; }
        public Nullable<decimal> Price3 { get; set; }
        public Nullable<int> EstimatedBalance { get; set; }
    
        public virtual ICollection<AdjustmentVoucherDetail> AdjustmentVoucherDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<DisbursementListDetail> DisbursementListDetails { get; set; }
        public virtual ICollection<PurchasingOrderDetail> PurchasingOrderDetails { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual ICollection<RequisitionDetail> RequisitionDetails { get; set; }
        public virtual StorageBin StorageBin { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Supplier Supplier4 { get; set; }
        public virtual Supplier Supplier5 { get; set; }
        public virtual UOM UOM { get; set; }
        public virtual ICollection<StationeryTransaction> StationeryTransactions { get; set; }
    }
}