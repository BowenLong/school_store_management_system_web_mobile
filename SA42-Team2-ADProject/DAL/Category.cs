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
    
    public partial class Category
    {
        public Category()
        {
            this.Stationeries = new HashSet<Stationery>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
    
        public virtual ICollection<Stationery> Stationeries { get; set; }
    }
}