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
    
    public partial class StorageBin
    {
        public StorageBin()
        {
            this.Stationeries = new HashSet<Stationery>();
        }
    
        public string Bin { get; set; }
        public int Status { get; set; }
    
        public virtual ICollection<Stationery> Stationeries { get; set; }
        public virtual StorageBin StorageBin1 { get; set; }
        public virtual StorageBin StorageBin2 { get; set; }
    }
}
