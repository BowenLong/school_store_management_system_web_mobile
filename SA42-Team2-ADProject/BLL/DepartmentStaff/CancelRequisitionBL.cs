using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DepartmentStaff
{
    public class CancelRequisitionBL
    {
        Entities ctx;

        public bool cancelRequisition(Requisition r)
        {
            ctx = new Entities();
            Requisition fromDB = ctx.Requisitions.Where(x => x.RequisitionId == r.RequisitionId).First();
            fromDB.Status = Util.RequisitionStatus.Canceled.ToString();
            return (ctx.SaveChanges() > 0);
        }


    }
}
