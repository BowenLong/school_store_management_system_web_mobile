using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAL;
using BLL.StoreClerk;

namespace BLL
{
    public class StationeryBL
    {
        Entities ctx;
        ReminderBL reminderBl;

        public List<UOM> getAllUnitOfMeasure()
        {
            ctx = new Entities();
            return ctx.UOMs.ToList();
        }

        public List<StorageBin> getAllBin()
        {
            ctx = new Entities();
            return ctx.StorageBins.ToList();
        }

        public List<Category> getAllCategories()
        {
            ctx = new Entities();
            return ctx.Categories.ToList();
        }

        public List<Stationery> getAllStationeries()
        {
            ctx = new Entities();
            return ctx.Stationeries.ToList();
        }

        public Stationery getStationeryById(string id)
        {
            ctx = new Entities();
            return ctx.Stationeries.Where(x => x.StationeryId == id).First();
        }
        public List<Stationery> getAllStationeriesByCategory(int categoryId)
        {
            ctx = new Entities();

            return ctx.Stationeries.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<StationeryTransaction> getStockCardForStationery(Stationery s, DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            return ctx.StationeryTransactions.Where(x => (x.StationeryID == s.StationeryId) && (fromDate <= x.TransactionDate && x.TransactionDate <= toDate)).ToList();
        }

        public bool createNewStationery(Stationery s)
        {
            using(var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    int result = 0;
                    ctx = new Entities();
                    Stationery toAdd = new Stationery();
                    toAdd.StationeryId = s.StationeryId;
                    toAdd.Description = s.Description;
                    toAdd.CategoryId = s.CategoryId;
                    toAdd.ReorderLevel = s.ReorderLevel;
                    toAdd.ReorderQuantity = s.ReorderQuantity;
                    toAdd.UOMId = s.UOMId;
                    toAdd.Bin = s.Bin;
                    toAdd.Supplier1 = s.Supplier1;
                    toAdd.Supplier2 = s.Supplier2;
                    toAdd.Supplier3 = s.Supplier3;
                    toAdd.Price1 = s.Price1;
                    toAdd.Price2 = s.Price2;
                    toAdd.Price3 = s.Price3;
                    toAdd.EstimatedBalance = 0;
                    //Add New to Stationery Transaction            
                    ctx.Stationeries.Add(toAdd);
                    result = ctx.SaveChanges();

                    StationeryTransaction stationeryTransaction = new StationeryTransaction()
                    {
                        StationeryID = s.StationeryId,
                        Participant = "Add New Stationery",
                        TransactionQuantity = 0,
                        TransactionDate = System.DateTime.Today.Date
                    };
                    createNewStationeryTransaction(stationeryTransaction);
                }
                catch (Exception ex)
                {
                    return false;
                }
                ts.Complete();
                return true;
            }
        }

        public bool updateStationery(Stationery s)
        {
            ctx = new Entities();
            Stationery toUpdate = ctx.Stationeries.Where(x => x.StationeryId == s.StationeryId).First();
            toUpdate.Description = s.Description;
            toUpdate.CategoryId = s.CategoryId;
            toUpdate.ReorderLevel = s.ReorderLevel;
            toUpdate.ReorderQuantity = s.ReorderQuantity;
            toUpdate.UOMId = s.UOMId;
            toUpdate.Bin = s.Bin;
            toUpdate.Supplier1 = s.Supplier1;
            toUpdate.Supplier2 = s.Supplier2;
            toUpdate.Supplier3 = s.Supplier3;
            toUpdate.Price1 = s.Price1;
            toUpdate.Price2 = s.Price2;
            toUpdate.Price3 = s.Price3;
            toUpdate.EstimatedBalance = 0;
            return (ctx.SaveChanges() > 0);
        }

        public bool createNewStationeryTransaction(StationeryTransaction st)
        {
            ctx = new Entities();
            reminderBl = new ReminderBL();
            string outstandingStatus = Util.ReminderType.Outstanding.ToString();
            StationeryTransaction last = ctx.StationeryTransactions.Where(x => x.StationeryID == st.StationeryID).ToList().Last();
            st.Balance = last.Balance + st.TransactionQuantity;
            ctx.StationeryTransactions.Add(st);
            //Insert to Reminder as Reorder Item
            Stationery stationery = ctx.Stationeries.Where(x => x.StationeryId == st.StationeryID && x.ReorderLevel > st.Balance).FirstOrDefault();

            if(stationery!=null)
            {
                Reminder r = new Reminder();
                r.ReminderType = Util.ReminderType.Reorder.ToString();
                r.StationeryId = st.StationeryID;
                r.Qty = stationery.ReorderQuantity;
                r.Reason = Util.ReminderType.Reorder.ToString();
                r.Status = Util.ReminderStatus.InList;
                reminderBl.createNewReminder(r);
            }
            return (ctx.SaveChanges() > 0);
        }

        public int updateEstimatedBalance(int qty, string stationeryId)
        {
            ctx = new Entities();
            int? result = null;
            Stationery s = ctx.Stationeries.Where(x => x.StationeryId == stationeryId).First();
            if (s.EstimatedBalance == null)
            {
                s.EstimatedBalance = s.StationeryTransactions.OrderByDescending(x => x.TransactionDate).First().Balance;
                if (s.EstimatedBalance == null)
                    s.EstimatedBalance = 0;
                s.EstimatedBalance -= qty;
                result = qty;
            }
            else if (s.EstimatedBalance < 0)
            {
                result = 0;
            }
            else if (s.EstimatedBalance < qty)
            {
                result = (int)s.EstimatedBalance;
                s.EstimatedBalance -= qty;
            }
            else
            {
                result = qty;
                s.EstimatedBalance -= qty;
            }
            ctx.SaveChanges();
            return (int)result;
        }

    }
}
