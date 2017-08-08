using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Stationery
    {
        public int TotalRequest { get { return this.DisbursementListDetails.Sum(x => x.RequestQty); } }

        public string Title { get { return Description + "-----Unit of measure: " + UOM; } }
    }

  
}
