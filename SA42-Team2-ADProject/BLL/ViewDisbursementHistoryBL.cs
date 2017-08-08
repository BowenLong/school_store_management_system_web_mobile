using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ViewDisbursementHistoryBL
    {
        Entities ctx;

        public List<DisbursementList> getAllDisbursementListsByStore(string departmentID, DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            string disbursedStatus = Util.DisbursementStatus.Disbursed.ToString();
            string finalStatus = Util.DisbursementStatus.Final.ToString();
            return ctx.DisbursementLists.Where(x => (x.Status == disbursedStatus || x.Status == finalStatus) && (fromDate <= x.DisbursementDate && x.DisbursementDate <= toDate)).ToList();
        }

        public List<DisbursementList> getAllDisbursementListsByDepartment(string departmentID, DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            string status = Util.DisbursementStatus.Disbursed.ToString();
            return ctx.DisbursementLists.Where(x => x.DepartmentId == departmentID && x.Status == status && fromDate <= x.DisbursementDate && x.DisbursementDate <= toDate).ToList();
        }

        public List<DisbursementList> getAllDisbursementLists(string departmentID, DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            return ctx.DisbursementLists.Where(x => (x.DepartmentId == departmentID) && (fromDate <= x.DisbursementDate && x.DisbursementDate <= toDate)).ToList();
        }

        public DisbursementList getDisbursementListDetail(int disbursementId)
        {
            return ctx.DisbursementLists.Where(x => x.DisbursementListId == disbursementId).First();
        }

    }
}
