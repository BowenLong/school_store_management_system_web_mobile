using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.StoreHead;

namespace ADProject
{
    public partial class StoreManager : System.Web.UI.MasterPage
    {
        Employee emp = new Employee();
        InformAdjustmentBL informAdjustmentBl;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            if (emp != null)
            {
                lblUsername.Text = emp.EmployeeName;
                informAdjustmentBl = new InformAdjustmentBL(emp);
                List<AdjustmentVoucher> avList = informAdjustmentBl.getAdjustmentVoucherReminderToApprove();
                AdjustmentReminderlb.Text = avList.Count().ToString();
                Notificationlb.Text = avList.Count().ToString();

                gvAdjustment.DataBind();
                
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            WebUtil.logoutAccount(Response, Session);
        }
    }
}