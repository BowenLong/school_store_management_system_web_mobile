using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DepartmentStaff
{
    public class ViewRequisitionHistoryBL
    {
        Employee employee;
        Entities ctx;
        string status = Util.RequisitionStatus.Pending.ToString();

        public ViewRequisitionHistoryBL(Employee e)
        {
            employee = e;
        }

        public List<Requisition> getRequisitionListByDateRange(DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            return ctx.Requisitions.OrderBy(x=>x.RequestDate).Where(x => (fromDate <= x.RequestDate) && (x.RequestDate <= toDate) && (x.EmployeeId == employee.EmployeeId)).ToList();
        }

        public List<Requisition> getPendingRequisitionListByDateRange(DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            return ctx.Requisitions.OrderBy(x => x.RequestDate).Where(x => (fromDate <= x.RequestDate) && (x.RequestDate <= toDate) && (x.EmployeeId == employee.EmployeeId) && (x.Status==status)).ToList();
        }

        public Requisition getRequisitionById(int requisitionId)
        {
            ctx = new Entities();
            return ctx.Requisitions.Where(x =>x.RequisitionId == requisitionId).First();
        }
 
        
    }
}
