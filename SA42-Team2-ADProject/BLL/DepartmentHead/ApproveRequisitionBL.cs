using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Transactions;
using BLL.DepartmentStaff;

namespace BLL.DepartmentHead
{
    public class ApproveRequisitionBL
    {
        
        Entities ctx;
        Employee e;

        public ApproveRequisitionBL(Employee e)
        {
            this.e = e;
        }

        public List<Requisition> getAllPendingRequisitions()
        {
            ctx = new Entities();
            string status =Util.RequisitionStatus.Pending.ToString();
            return ctx.Requisitions.OrderBy(x=>x.RequestDate).Where(x => (x.Status == status) && (x.Employee.DepartmentId == e.DepartmentId)).ToList();
        }

        public Requisition getRequisitionById(int id)
        {
            ViewRequisitionHistoryBL bl = new ViewRequisitionHistoryBL(e);
            return bl.getRequisitionById(id);
        }


        public bool approveRequisition(Requisition r)
        {

            ctx = new Entities();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    CreateDisbursementListBL bl = new CreateDisbursementListBL(e);
                    StationeryBL stationeryBL = new StationeryBL();
                    DisbursementList dList = bl.createNewDisbursementList();
                    List<DisbursementListDetail> dldList = dList.DisbursementListDetails.ToList();
                    foreach (RequisitionDetail rd in r.RequisitionDetails.ToList())
                    {
                        DisbursementListDetail toAdd;
                        if (dldList.Count > 0)
                        {
                            //totally new requisition detail in disbursement detail table
                            toAdd = dldList.Where(x => x.StationeryId == rd.StationeryId).FirstOrDefault();
                            if (toAdd == null)
                            {
                                toAdd = new DisbursementListDetail();
                                toAdd.DisbursementListId = dList.DisbursementListId;
                                toAdd.StationeryId = rd.StationeryId;
                                toAdd.RequestQty = rd.Qty;
                                toAdd.GivenQty = 0;
                                ctx.DisbursementListDetails.Add(toAdd);
                            }
                            //if there is one record existed for department in the table
                            else
                            {
                                DisbursementListDetail dd = ctx.DisbursementListDetails.Where(x => x.DisbursementListDetailId == toAdd.DisbursementListDetailId).FirstOrDefault();
                                toAdd = dd;
                                toAdd.RequestQty += rd.Qty;
                            }
                        }
                        else
                        {
                            toAdd = new DisbursementListDetail();
                            toAdd.DisbursementListId = dList.DisbursementListId;
                            toAdd.StationeryId = rd.StationeryId;
                            toAdd.RequestQty = rd.Qty;
                            toAdd.GivenQty = 0;
                            ctx.DisbursementListDetails.Add(toAdd);
                        }
                        toAdd.GivenQty += stationeryBL.updateEstimatedBalance(rd.Qty, rd.StationeryId);
                        ctx.SaveChanges();
                    }
                    changeApproveRequisition(r);
                }
                catch (Exception e)
                {
                    return false;
                }
                ts.Complete();
                return true;
            }
        }

        public bool rejectRequisition(Requisition r)
        {
                ctx = new Entities();
                Requisition fromDB = ctx.Requisitions.Where(x => x.RequisitionId == r.RequisitionId).FirstOrDefault();
                fromDB.Status = Util.RequisitionStatus.Rejected.ToString();
                return (ctx.SaveChanges() > 0);
        }

        public bool changeApproveRequisition(Requisition r)
        {
            ctx = new Entities();
            Requisition fromDB = ctx.Requisitions.Where(x => x.RequisitionId == r.RequisitionId).FirstOrDefault();
            fromDB.Status = Util.RequisitionStatus.Approved.ToString();
            return (ctx.SaveChanges() > 0);
        }
    }
}
