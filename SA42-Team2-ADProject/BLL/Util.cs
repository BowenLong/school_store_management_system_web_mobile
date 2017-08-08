using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Util
    {
        
        public enum RequisitionStatus{Pending,Approved,Rejected,Canceled}

        public enum DisbursementStatus { Pending, Retrieval, Final, Disbursed }

        public enum AdjustmentStatus { Pending, Approved,Canceled }

        public enum BinStatus { Unavailable = 1, Uncollected = 2, Collected = 3 }

        public struct ReminderStatus{
            public static bool InList { get { return true; } }
            public static bool Checked { get { return false; } }
        }

        public enum ReminderType { Adjustment,Reorder,Outstanding }
        public enum Roles { Employee =1,StoreClerk=2,StoreSupervisor=3,StoreManager=4,DepartmentHead=5}
        public enum MessageType { NeedToApprove = 1, ApprovedOrRejected = 2, ReadyDisbursement = 3 }

    }
}
