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
    
    public partial class CollectionPoint
    {
        public CollectionPoint()
        {
            this.Departments = new HashSet<Department>();
        }
    
        public int CollectionPointID { get; set; }
        public string CollectionPointName { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
    
        public virtual ICollection<Department> Departments { get; set; }
    }
}