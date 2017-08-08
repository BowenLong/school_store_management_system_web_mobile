using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreClerk
{
    public class ReminderBL
    {
        Entities ctx;
        string reminderType;

        //In the Reminder List => Status=True
        //After Submit ==> Status = False
        public List<Reminder> getReminderForAdjustmentList()
        {
            ctx = new Entities();
            reminderType = Util.ReminderType.Adjustment.ToString();
            return ctx.Reminders.Where(x => x.ReminderType.Equals(reminderType) && x.Status == Util.ReminderStatus.InList).ToList();
        }

        public List<Reminder> getReminderForReorderList()
        {
            ctx = new Entities();
            reminderType = Util.ReminderType.Reorder.ToString();
            return ctx.Reminders.Where(x => x.ReminderType.Equals(reminderType) && x.Status == Util.ReminderStatus.InList).ToList();
        }
        public List<Reminder> getReminderForOutstandingList()
        {
            ctx = new Entities();
            reminderType = Util.ReminderType.Outstanding.ToString();
            return ctx.Reminders.Where(x => x.ReminderType.Equals(reminderType) && x.Status == Util.ReminderStatus.InList).ToList();
        }

        public bool updateReminder(List<Reminder> rList)
        {
            

            int result = 0;
            ctx = new Entities();
            foreach (Reminder r in rList)
            {
                Reminder toUpdate = ctx.Reminders.Where(x => x.ReminderId == r.ReminderId).FirstOrDefault();
                if (r.ReminderType.Equals(Util.ReminderType.Reorder.ToString()))
                {
                    if (r.Qty < toUpdate.Qty) //If the Reorder Qty is Less than the Qty in Reminder still remaind as ReOrder Reminder
                    {
                        toUpdate.Status = Util.ReminderStatus.InList;
                        toUpdate.Qty = r.Qty;
                        toUpdate.Reason = r.Reason;
                        result = ctx.SaveChanges();
                    }
                    else
                    {
                        toUpdate.Status = Util.ReminderStatus.Checked;
                        toUpdate.Reason = r.Reason;
                        result = ctx.SaveChanges();
                    }
                }
                else //Other ReminderType To Update
                {
                    toUpdate.Status = Util.ReminderStatus.Checked;
                    toUpdate.Reason = r.Reason;
                    result = ctx.SaveChanges();
                }
            }
            return (result > 0);
        }

        public bool createNewReminder(Reminder r)
        {
            ctx = new Entities();
            Reminder toAdd;
            Reminder fromDb;
            //foreach (Reminder r in rList)
            //{
            string reorder = Util.ReminderType.Reorder.ToString();
            string outstanding = Util.ReminderType.Outstanding.ToString();
            string adjustiment = Util.ReminderType.Adjustment.ToString();
            if (r.ReminderType.Equals(reorder))
            {
                fromDb = ctx.Reminders.Where(x => x.Status == Util.ReminderStatus.InList && x.StationeryId == r.StationeryId && (x.ReminderType == reorder)).FirstOrDefault();
                if(fromDb==null)
                {
                    toAdd = new Reminder();
                    toAdd.StationeryId = r.StationeryId;
                    toAdd.Qty = r.Qty;
                    toAdd.Status = Util.ReminderStatus.InList;
                    toAdd.Reason = r.Reason;
                    toAdd.ReminderType = r.ReminderType;
                    ctx.Reminders.Add(toAdd);
                }                    
                
            }

            if (r.ReminderType.Equals(outstanding) || r.ReminderType.Equals(adjustiment))
            {
                fromDb = ctx.Reminders.Where(x => x.Status == Util.ReminderStatus.InList && x.StationeryId == r.StationeryId && (x.ReminderType.Equals(adjustiment) || x.ReminderType.Equals(outstanding))).FirstOrDefault();
                if (fromDb != null)
                {
                    fromDb.Qty += r.Qty;
                }
                else
                {
                    toAdd = new Reminder();
                    toAdd.StationeryId = r.StationeryId;
                    toAdd.Qty = r.Qty;
                    toAdd.Status = Util.ReminderStatus.InList;
                    toAdd.Reason = r.Reason;
                    toAdd.ReminderType = r.ReminderType;
                    ctx.Reminders.Add(toAdd);
                }
            }

            //}            
            return (ctx.SaveChanges() > 0);
        }



    }
}
