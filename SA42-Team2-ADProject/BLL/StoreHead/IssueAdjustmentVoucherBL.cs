using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;
using DAL;

namespace BLL.StoreHead
{
    public class IssueAdjustmentVoucherBL
    {
        Employee e;
        Entities ctx;

        public IssueAdjustmentVoucherBL(Employee e)
        {
            this.e = e;
        }

        //public void updateAdjustmentVoucherToApprove(int adjustmentVoucherId, List<AdjustmentVoucherDetail> adjDetailList)
        //{
        //    ctx = new Entities();
        //    StationeryBL stationeryBL = new StationeryBL();
        //    AdjustmentVoucher toUpdate = ctx.AdjustmentVouchers.Where(x => x.AdjustmentVCId == adjustmentVoucherId).First();
        //    toUpdate.ApprovalStatus = Util.AdjustmentStatus.Approved.ToString();
        //    toUpdate.ApproveDate = DateTime.Today.Date;
        //    ctx.SaveChanges();

        //    foreach (AdjustmentVoucherDetail adjDetail in adjDetailList)
        //    {
        //        StationeryTransaction stockCard = new StationeryTransaction();
        //        stockCard.Participant = "Stock Adjustment : #" + adjDetail.AdjustmentVCId;
        //        stockCard.TransactionDate = DateTime.Today.Date;
        //        stockCard.StationeryID = adjDetail.StationeryId;
        //        stockCard.TransactionQuantity = adjDetail.QtyAdjusted;
        //        stationeryBL.createNewStationeryTransaction(stockCard);
        //    }
        //} 

        public bool updateAdjustmentVoucherToApprove(AdjustmentVoucher adjustmentVoucher,string status)
        {
            ctx = new Entities();
            using(var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                StationeryBL stationeryBL = new StationeryBL();
                AdjustmentVoucher toUpdate = ctx.AdjustmentVouchers.Where(x => x.AdjustmentVCId == adjustmentVoucher.AdjustmentVCId).FirstOrDefault();
                try
                {
                    if(status==Util.AdjustmentStatus.Approved.ToString())
                    {                       
                        toUpdate.ApprovalStatus = status;
                        toUpdate.ApproveDate = DateTime.Today.Date;
                        ctx.SaveChanges();

                        foreach (AdjustmentVoucherDetail adjDetail in adjustmentVoucher.AdjustmentVoucherDetails)
                        {
                            StationeryTransaction stockCard = new StationeryTransaction();
                            stockCard.Participant = "Stock Adjustment : #" + adjDetail.AdjustmentVCId;
                            stockCard.TransactionDate = DateTime.Today.Date;
                            stockCard.StationeryID = adjDetail.StationeryId;
                            stockCard.TransactionQuantity = adjDetail.QtyAdjusted;
                            stationeryBL.createNewStationeryTransaction(stockCard);
                        }
                    }
                    else if(status==Util.AdjustmentStatus.Canceled.ToString())
                    {
                        toUpdate.ApprovalStatus = status;
                        toUpdate.ApproveDate = DateTime.Today.Date;
                        ctx.SaveChanges();
                    }
                    
                }
                catch (Exception ex)
                {
                    return false;
                }
                ts.Complete();
                return true;
            }
        }

    }
}
