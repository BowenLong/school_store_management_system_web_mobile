using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
namespace BLL.StoreClerk
{
    public class DisburseStationeryBL
    {
        Entities ctx;

        public List<CollectionPoint> getCollectionPointList()
        {
            ctx = new Entities();
            string status = Util.DisbursementStatus.Final.ToString();
            return ctx.DisbursementLists.Where(x => x.Status == status).Select(x => x.Department.CollectionPoint).Distinct().ToList();
        }

        //public List<Department> getDepartmentListForCollectionPoint(CollectionPoint c)
        //{
        //    ctx = new Entities();
        //    return ctx.Departments.Where(x => x.CollectionPointId == c.CollectionPointID).ToList();
        //}
        public List<Department> getDepartmentListForCollectionPoint(int collectionPointID)
        {
            ctx = new Entities();
            List<Department> result = new List<Department>();
            string status = Util.DisbursementStatus.Final.ToString();
            ctx.DisbursementLists.Where(x => x.Status.Equals(status) && x.Department.CollectionPointId == collectionPointID).ToList().ForEach(y => result.Add(y.Department));
            return result;
        }

        //public DisbursementList getDisbursementListForDepartment(Department d)
        //{
        //    ctx = new Entities();
        //    string status = Util.DisbursementStatus.Final.ToString();
        //    return ctx.DisbursementLists.Where(x => x.DepartmentId == d.DepartmentId && x.Status == status).First();
        //} 
        public DisbursementList getDisbursementListForDepartment(string deptid)
        {
            ctx = new Entities();
            string status = Util.DisbursementStatus.Final.ToString();
            return ctx.DisbursementLists.Where(x => x.DepartmentId.Equals(deptid) && x.Status == status).First();
        }


        public bool confirmDisbursementList(DisbursementList dList)
        {
            StationeryBL sBL = new StationeryBL();
            ctx = new Entities();
            DisbursementList d = ctx.DisbursementLists.Where(x => x.DisbursementListId == dList.DisbursementListId).First();
            d.Status = Util.DisbursementStatus.Disbursed.ToString();
            d.SignatureURL = dList.SignatureURL;
            d.DisbursementDate = DateTime.Today.Date;
            foreach (DisbursementListDetail dld in dList.DisbursementListDetails)
            {
                DisbursementListDetail fromDB = ctx.DisbursementListDetails.Where(x => x.DisbursementListDetailId == dld.DisbursementListDetailId).First();
                fromDB.ReceivedQty = dld.ReceivedQty;
                if (!sBL.createNewStationeryTransaction(new StationeryTransaction() { TransactionDate = DateTime.Today, Participant = d.Department.DepartmentName, StationeryID = fromDB.StationeryId, TransactionQuantity = -fromDB.ReceivedQty }))
                {
                    return false;
                }
            }
            //Send Mail to Deaprtment Head
            sendEmail.sendMailToEmployeeForDisbursement(d);
            return (ctx.SaveChanges() > 0);

            //ctx.DisbursementLists.Where(x => x.DisbursementListId == dl.DisbursementListId).First().Status = Util.DisbursementStatus.Disbursed.ToString();
            //foreach (DisbursementListDetail dld in dl.DisbursementListDetails)
            //{
            //    DisbursementListDetail fromDB = ctx.DisbursementListDetails.Where(x => x.DisbursementListDetailId == dld.DisbursementListDetailId).First();
            //    fromDB.ReceivedQty = dld.ReceivedQty;
            //    if (!sBL.createNewStationeryTransaction(new StationeryTransaction() { TransactionDate = DateTime.Today, Participant = dl.Department.DepartmentName, StationeryID = fromDB.StationeryId, TransactionQuantity = -fromDB.ReceivedQty }))
            //    {
            //        return false;
            //    }
            //}
            //return(ctx.SaveChanges()>0);
        }
    }
}
       
    

