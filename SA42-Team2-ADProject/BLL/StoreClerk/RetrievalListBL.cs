using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreClerk
{
    public class RetrievalListBL
    {
        Entities ctx;
        public List<DateTime> getRetrievalListByDateRange(DateTime fromDate, DateTime toDate)
        {
            ctx = new Entities();
            return ctx.RetrievalLists.Where(x => x.RetriveDate.HasValue && fromDate <= x.RetriveDate && x.RetriveDate <= toDate).Select(x => (DateTime)x.RetriveDate).Distinct().ToList();
        }

        public List<BinForRetrieval> getRetrievalList(DateTime retrieveDate)
        {
            ctx = new Entities();
            List<DisbursementListDetail> sourceList = ctx.DisbursementListDetails.Where(x => x.DisbursementList.RetriveDate == retrieveDate).ToList();
            return fetchBinForRetrievalData(sourceList);
        }

        public List<BinForRetrieval> getRetrievalList()
        {
            ctx = new Entities();
            string status = Util.DisbursementStatus.Retrieval.ToString();
            List<DisbursementListDetail> sourceList = ctx.DisbursementListDetails.Where(x => x.DisbursementList.Status == status).ToList();
            return fetchBinForRetrievalData(sourceList);
        }

        public bool updateBinList(string binId)
        {
            ctx = new Entities();
            ctx.StorageBins.Where(x => x.Bin.Equals(binId)).First().Status = (int)Util.BinStatus.Collected;
            return (ctx.SaveChanges() > 0);
        }

        List<BinForRetrieval> fetchBinForRetrievalData(List<DisbursementListDetail> sourceList)
        {
            //List<BinForRetrieval> result = new List<BinForRetrieval>();
            //sourceList.GroupBy(x => x.Stationery.Bin).Distinct().ToList().ForEach(x => result.Add(new BinForRetrieval() { Bin = x.Key }));
            //foreach (var v in result)
            //{
            //    v.Stationeries = sourceList.Where(x => x.Stationery.Bin == v.Bin).GroupBy(x => x.Stationery).Select(x => new StationeryForRetrieval() { Description = x.Key.Description, StationeryId = x.Key.StationeryId }).ToList();
            //    v.Stationeries.ForEach(x => x.detailList = sourceList.Where(y => y.StationeryId == x.StationeryId).Select(z => new RetrievalDetail() { DepartmentName = z.DisbursementList.Department.DepartmentName, DisbursementListDetailId = z.DisbursementListDetailId, Needed = z.RequestQty, Given = z.GivenQty ?? default(int) }).ToList());
            //}

            //return result;

            List<BinForRetrieval> result = new List<BinForRetrieval>();
            sourceList.GroupBy(x => x.Stationery.StorageBin).Distinct().ToList().ForEach(x => result.Add(new BinForRetrieval() { Bin = x.Key.Bin, BinStatus = x.Key.Status }));
            foreach (var v in result)
            {
                v.Stationeries = sourceList.Where(x => x.Stationery.Bin == v.Bin).GroupBy(x => x.Stationery).Select(x => new StationeryForRetrieval() { Description = x.Key.Description, StationeryId = x.Key.StationeryId, UOM = x.Key.UOM.UOMDescription }).ToList();
                v.Stationeries.ForEach(x => x.detailList = sourceList.Where(y => y.StationeryId == x.StationeryId).Select(z => new RetrievalDetail() { DepartmentName = z.DisbursementList.Department.DepartmentName, DisbursementListDetailId = z.DisbursementListDetailId, Needed = z.RequestQty, Given = z.GivenQty ?? default(int) }).ToList());
            }

            return result;
        }

        public List<StationeryForRetrieval> getStationeryListForBin(string binId)
        {
            return getRetrievalList().Where(x => x.Bin == binId).First().Stationeries;

        }

        public bool generateRetrievalList()
        {
            ctx = new Entities();
            foreach (var v in ctx.DisbursementLists.ToList())
            {
                if (v.Status == Util.DisbursementStatus.Pending.ToString())
                {
                    v.Status = Util.DisbursementStatus.Retrieval.ToString();
                    v.RetriveDate = DateTime.Today;
                    updateBinToUncollected(v);
                }
            }

            return (ctx.SaveChanges() > 0);
        }

         void updateBinToUncollected(DisbursementList d)
        {
            d.DisbursementListDetails.GroupBy(x => x.Stationery).ToList().ForEach(y => y.Key.StorageBin.Status = (int)Util.BinStatus.Uncollected);
        }

        public string updateGivenQtyForBin(List<RetrievalDetail> binDetailList)
        {
            ctx = new Entities();
            string msg = "ok";
            bool isEqual = false;
            
            foreach (RetrievalDetail rd in binDetailList)
            {
                if (rd.Needed <  rd.Given)
                {
                    msg = "The actual quantity cannot be greater than the request quantity for department: "+rd.DepartmentName;
                    return msg;
                }

                if (ctx.DisbursementListDetails.Where(x => x.DisbursementListDetailId == rd.DisbursementListDetailId).FirstOrDefault().GivenQty == rd.Given)
                {
                    isEqual = true;
                }
                else{
                    ctx.DisbursementListDetails.Where(x => x.DisbursementListDetailId == rd.DisbursementListDetailId).FirstOrDefault().GivenQty = rd.Given;
                }
                 
            }
            if (ctx.SaveChanges() > 0 || isEqual)
            {
                return msg;
            }
            else
            {
                msg = "Failed to update the actual quantity";
                return msg;
            }
        }
        public bool confirmRetrievalList()
        {
            
            ctx = new Entities();
            if (ctx.StorageBins.Where(x => x.Status == (int)Util.BinStatus.Uncollected).ToList().Count == 0)
            {
                string oldStatus = Util.DisbursementStatus.Retrieval.ToString();
                string newStatus = Util.DisbursementStatus.Final.ToString();
                ctx.DisbursementLists.Where(x => x.Status == oldStatus).ToList().ForEach(x => x.Status = newStatus);
                ctx.DisbursementLists.Where(x=>x.Status == oldStatus).ToList().ForEach(x=>x.DisbursementListDetails.ToList().ForEach(y=>y.ReceivedQty=y.GivenQty));
                ctx.StorageBins.Where(x => x.Status == (int)Util.BinStatus.Collected).ToList().ForEach(y => y.Status = (int)Util.BinStatus.Unavailable);
                return (ctx.SaveChanges() > 0);
            }
            else return false;
        
        }
    

        public void addOutstandingReminder(Entities ctx)
        {
            ReminderBL reminderBl = new ReminderBL();
            string finalStatus = Util.DisbursementStatus.Final.ToString();
            List<DisbursementList> disbursementList = ctx.DisbursementLists.Where(x => x.Status == finalStatus).ToList();
            foreach (DisbursementList dl in disbursementList)
            {
                foreach (DisbursementListDetail d in dl.DisbursementListDetails)
                {
                    if(d.GivenQty<d.RequestQty)
                    {
                        Reminder reminder = new Reminder();
                        reminder.StationeryId = d.StationeryId;
                        reminder.Qty = Convert.ToInt32(d.RequestQty - d.GivenQty);
                        reminder.Status = Util.ReminderStatus.InList;
                        reminder.Reason = Util.ReminderType.Outstanding.ToString();
                        reminder.ReminderType = Util.ReminderType.Outstanding.ToString();
                        reminderBl.createNewReminder(reminder);
                    }
                    
                }
            }

        }
    }








}
