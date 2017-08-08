using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DepartmentHead
{
    public class CreateDisbursementListBL
    {
        Employee e;
        Entities ctx;

        public CreateDisbursementListBL(Employee e)
        {
            this.e = e;
        }
        public DisbursementList createNewDisbursementList()
        {
            ctx = new Entities();
            String status= Util.DisbursementStatus.Pending.ToString();
            List<DisbursementList> fromDB = ctx.DisbursementLists.Where(x => (x.DepartmentId == e.DepartmentId) && (x.Status == status)).ToList();
            if (fromDB.Count <= 0)
            {
                DisbursementList dl = new DisbursementList();
                dl.DepartmentId = e.DepartmentId;
                dl.Status = Util.DisbursementStatus.Pending.ToString();
                ctx.DisbursementLists.Add(dl);
                ctx.SaveChanges();
                return dl;
            }
            else return fromDB.First();
        }
    }
}
