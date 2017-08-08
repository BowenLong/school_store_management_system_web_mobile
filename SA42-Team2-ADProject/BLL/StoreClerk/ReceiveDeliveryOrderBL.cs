using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAL;

namespace BLL.StoreClerk
{
    public class ReceiveDeliveryOrderBL
    {
        Entities ctx;
        ReminderBL reminderBl;
        StationeryBL stationeryBL;

        public PurchasingOrder getPurchasingOrderByPOId(int POid)
        {
            ctx = new Entities();
            return ctx.PurchasingOrders.Where(x => x.POId == POid && x.DeliveryDate==null).FirstOrDefault();
        }

        //Old One
        //public bool receiveDeliveryOrder(PurchasingOrder po)
        //{
        //    ctx = new Entities();
        //    PurchasingOrder toUpdate = ctx.PurchasingOrders.Where(x => x.POId == po.POId).First();
        //    toUpdate.PurchasingOrderDetails = po.PurchasingOrderDetails;
        //    return(ctx.SaveChanges()>0);
        //}

        public bool receiveDeliveryOrder(PurchasingOrder po)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    ctx = new Entities();
                    reminderBl = new ReminderBL();
                    stationeryBL = new StationeryBL();
                    Reminder toAddReminder = new Reminder();
                    //List<Reminder> rList = new List<Reminder>();

                    PurchasingOrder toUpdate = ctx.PurchasingOrders.Where(x => x.POId == po.POId).FirstOrDefault();
                    toUpdate = po;
                    ctx.SaveChanges();

                    //po.PurchasingOrderDetails.Where(x => x.ReceivedQty > x.OrderQty).ToList()
                    //    .ForEach(x => rList.Add(new Reminder()
                    //    {
                    //        StationeryId = x.StationeryId,
                    //        Qty = x.ReceivedQty - x.OrderQty,
                    //        Reason = "Gift",
                    //        ReminderType = Util.ReminderType.Adjustment.ToString(),
                    //        Status = Util.ReminderStatus.InList
                    //    }));
                    //Save Gift Item For Reminder ==> ReminderType is Adjustment
                    foreach (PurchasingOrderDetail poDetail in toUpdate.PurchasingOrderDetails)
                    {

                        StationeryTransaction sTransaction = new StationeryTransaction()//Add to transaction stationery <Stock Card>
                        {
                            TransactionDate = DateTime.Today,
                            Participant = "Supplier: " + po.Supplier.SupplierName,
                            StationeryID = poDetail.StationeryId,

                        };

                        if (poDetail.ReceivedQty > poDetail.OrderQty) //Consider as Gift and Add to Reminder
                        {
                            toAddReminder = new Reminder()
                            {
                                StationeryId = poDetail.StationeryId,
                                Status = Util.ReminderStatus.InList,
                                Reason = "Gift",
                                ReminderType = Util.ReminderType.Adjustment.ToString()
                            };
                            toAddReminder.Qty = poDetail.ReceivedQty - poDetail.OrderQty;
                            //rList.Add(toAddReminder);
                            sTransaction.TransactionQuantity = toAddReminder.Qty;
                        }
                        else
                        {
                            sTransaction.TransactionQuantity = poDetail.ReceivedQty;
                        }
                        stationeryBL.createNewStationeryTransaction(sTransaction);
                        reminderBl.createNewReminder(toAddReminder);
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
