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
    
    public partial class RequisitionDetail
    {
        public int RequisitionDetailId { get; set; }
        public int RequisitionId { get; set; }
        public string StationeryId { get; set; }
        public int Qty { get; set; }
    
        public virtual Requisition Requisition { get; set; }
        public virtual Stationery Stationery { get; set; }
    }
}