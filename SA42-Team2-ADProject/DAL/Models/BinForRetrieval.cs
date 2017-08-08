using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BinForRetrieval
    {
        public string Bin { get; set; }

        public int BinStatus { get; set; }

        public DateTime RetrieveDate { get; set; }

        public List<StationeryForRetrieval> Stationeries { get; set; }

    }
}
