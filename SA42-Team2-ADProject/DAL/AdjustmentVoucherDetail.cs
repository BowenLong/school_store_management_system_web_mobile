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
    
    public partial class AdjustmentVoucherDetail
    {
        public int AdjustmentVCDId { get; set; }
        public int AdjustmentVCId { get; set; }
        public string StationeryId { get; set; }
        public int QtyAdjusted { get; set; }
        public string Reason { get; set; }
        
    
        public virtual Stationery Stationery { get; set; }
        public virtual AdjustmentVoucher AdjustmentVoucher { get; set; }
        public decimal Value { get; set; }

        public decimal CalculateValue()
        {
            return Math.Abs(this.QtyAdjusted) * this.Stationery.Price1 ?? default(decimal);
        }
    }
}
