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
    
    public partial class AdjustmentVoucher
    {
        public AdjustmentVoucher()
        {
            this.AdjustmentVoucherDetails = new HashSet<AdjustmentVoucherDetail>();
        }
    
        public int AdjustmentVCId { get; set; }
        public System.DateTime IssuedDate { get; set; }
        public string ApprovalStatus { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public int ApproveRole { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AdjustmentVoucherDetail> AdjustmentVoucherDetails { get; set; }
        public virtual Role Role { get; set; }
    }
}
