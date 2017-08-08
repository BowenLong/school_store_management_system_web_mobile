using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreHead
{
    public class InformAdjustmentBL
    {
        Employee e;
        Entities ctx;
        string adjStatus;

        public InformAdjustmentBL(Employee e)
        {
            this.e = e;
        }

        public List<AdjustmentVoucher> getAdjustmentVoucherToApproved()
        {
            adjStatus = Util.AdjustmentStatus.Pending.ToString();
            ctx = new Entities();
            return ctx.AdjustmentVouchers.Where(x => x.ApproveRole == e.RoleId && x.ApprovalStatus == adjStatus).ToList();
        }

        public List<AdjustmentVoucher> getAdjustmentVoucherReminderToApprove()
        {
            ctx = new Entities();
            List<AdjustmentVoucher> adjListForSupervisor = new List<AdjustmentVoucher>();
            List<AdjustmentVoucher> adjListForManager = new List<AdjustmentVoucher>();
            adjStatus = Util.AdjustmentStatus.Pending.ToString();

            List<AdjustmentVoucher> toAdjList = ctx.AdjustmentVouchers.Where(x => x.ApprovalStatus == adjStatus).ToList();
            foreach(AdjustmentVoucher voucher in toAdjList)
            {
                if(voucher.ApproveRole==(int)Util.Roles.StoreManager)
                {
                    adjListForManager.Add(voucher);
                }
                else
                {
                    adjListForSupervisor.Add(voucher);
                }
            }


            if(e.RoleId==(int)Util.Roles.StoreManager)
            {
                return adjListForManager;
            }
            else
            {
                return adjListForSupervisor;
            }
        }


        
    }
}
