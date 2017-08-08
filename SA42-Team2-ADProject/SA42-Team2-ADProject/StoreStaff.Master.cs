using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.StoreClerk;

namespace ADProject
{
    public partial class StoreStaff : System.Web.UI.MasterPage
    {
        Employee emp = new Employee();

        Stationery stationery = new Stationery();
        Reminder reminder = new Reminder();
        StationeryTransaction stationeryTransaction = new StationeryTransaction();
        ReminderBL reminderBL = new ReminderBL();        

        protected void Page_Load(object sender, EventArgs e)
        {

            emp = (Employee)Session["CurrentEmployee"];
            if (emp != null)
            {
                lblUsername.Text = emp.EmployeeName;

                ReorderReminderlb.Text = reminderBL.getReminderForReorderList().Count().ToString();
                AdjustmentReminderlb.Text = reminderBL.getReminderForAdjustmentList().Count().ToString();
                OutstandingReminderlb.Text = reminderBL.getReminderForOutstandingList().Count().ToString();

                Notificationlb.Text = getNotificationNumber().ToString();

                gvAdjustment.DataBind();
                gvOutstanding.DataBind();
                gvReorder.DataBind();
            }
        }

        protected void btnClear__Click(object sender, EventArgs e)
        {
            List<Reminder> outstandtingReminderList = reminderBL.getReminderForOutstandingList();
            reminderBL.updateReminder(outstandtingReminderList);
            Response.Redirect(Request.Url.ToString());


        }


        private int getNotificationNumber()
        {
            int reorderNum = reminderBL.getReminderForReorderList().Count()
               + reminderBL.getReminderForAdjustmentList().Count()
               + reminderBL.getReminderForOutstandingList().Count();
            return reorderNum;
        }

        protected void gvReorder_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["selectedItemStationeryID"] = gvReorder.SelectedDataKey.Value;


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            WebUtil.logoutAccount(Response, Session);
        }

    }
}