using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreClerk
{
    public class CreateNewAdjustmentVoucherBL
    {
        Entities ctx;

        public List<Reminder> loadAllPendingRemindersForAdjustment()
        {
            ctx = new Entities();
            string reminderType = Util.ReminderType.Adjustment.ToString();
            return ctx.Reminders.Where(x => x.Status == Util.ReminderStatus.InList && x.ReminderType == reminderType).ToList();
        }

        public bool createNewAdjustmentVoucher(List<AdjustmentVoucherDetail> avdList, int storeClerkId)
        {
            ctx = new Entities();
            AdjustmentVoucher vcSupervisor = new AdjustmentVoucher();
            vcSupervisor.IssuedDate = DateTime.Today;
            vcSupervisor.EmployeeId = storeClerkId;
            vcSupervisor.ApproveRole = (int)Util.Roles.StoreSupervisor;
            vcSupervisor.ApprovalStatus = Util.AdjustmentStatus.Pending.ToString();
            vcSupervisor.AdjustmentVoucherDetails = new List<AdjustmentVoucherDetail>();

            AdjustmentVoucher vcManager = new AdjustmentVoucher();
            vcManager.IssuedDate = DateTime.Today;
            vcManager.EmployeeId = storeClerkId;
            vcManager.ApproveRole = (int)Util.Roles.StoreManager;
            vcManager.ApprovalStatus = Util.AdjustmentStatus.Pending.ToString();
            vcManager.AdjustmentVoucherDetails = new List<AdjustmentVoucherDetail>();

            foreach (AdjustmentVoucherDetail avd in avdList)
            {
                avd.Stationery = ctx.Stationeries.Where(x => x.StationeryId == avd.StationeryId).FirstOrDefault();
                avd.Value = avd.CalculateValue();
                if (avd.Value > 250)
                {
                    vcManager.AdjustmentVoucherDetails.Add(avd);
                }
                else
                {
                    vcSupervisor.AdjustmentVoucherDetails.Add(avd);
                }
            }

            if (vcManager.AdjustmentVoucherDetails.Count > 0)
            {
                ctx.AdjustmentVouchers.Add(vcManager);
            }

            if (vcSupervisor.AdjustmentVoucherDetails.Count > 0)
            {
                ctx.AdjustmentVouchers.Add(vcSupervisor);
            }
            return (ctx.SaveChanges() > 0);
        }


    }
}
