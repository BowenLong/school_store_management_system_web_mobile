using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StationeryForRetrieval
    {
        public string StationeryId { get; set; }
        public string Description { get; set; }

        public int TotalRequest { get { return this.detailList.Sum(x => x.Needed); } }

        public int TotalGiven { get { return this.detailList.Sum(x => x.Given); } }
        public List<RetrievalDetail> detailList { get; set; }

        public string UOM { get; set; }

       

    }
}
