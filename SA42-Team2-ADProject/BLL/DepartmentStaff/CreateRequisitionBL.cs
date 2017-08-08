using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.DepartmentStaff
{
    public class CreateRequisitionBL
    {
        StationeryBL stationeryBL;
        Employee employee;
        Entities ctx;

        public CreateRequisitionBL(Employee e)
        {
            employee = e;
            stationeryBL = new StationeryBL();
        }

        public List<Category> getAllCategories()
        {
            return stationeryBL.getAllCategories();
        }

        public List<Stationery> getAllStationeriesByCategory(int categoryId)
        {
            return stationeryBL.getAllStationeriesByCategory(categoryId);
        }


        public bool createNewRequisition(List<RequisitionDetail> rdList)
        {
            ctx = new Entities();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                Requisition r = new Requisition();
                r.EmployeeId = employee.EmployeeId;
                r.RequestDate = DateTime.Today;
                r.Status = Util.RequisitionStatus.Pending.ToString();
                r.RequisitionDetails = rdList;
                ctx.Requisitions.Add(r);
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                ts.Complete();
                return true;
            }
        }
    }
}
