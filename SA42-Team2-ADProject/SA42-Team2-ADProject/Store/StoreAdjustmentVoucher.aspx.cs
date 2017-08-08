using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using BLL;
using BLL.StoreClerk;

namespace ADProject.Store
{
    public partial class StoreAdjustmentVoucher : System.Web.UI.Page
    {
        Employee emp = new Employee();
        StationeryBL stationeryBl = new StationeryBL();
        ReminderBL reminderBl = new ReminderBL();
        DataTable dt;
        DataRow dr;
        static List<Reminder> reminderList;

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            if (!Page.IsPostBack)
            {
                //Set GV Formate
                CreateDataTable();
                gvAdjustmentVoucherDetail.DataSource = ((DataTable)Session["NewAdjustmentDetailList"]);
                gvAdjustmentVoucherDetail.DataBind();


                stationeryBl = new StationeryBL();
                ddlCategory.DataSource = stationeryBl.getAllCategories();
                ddlCategory.DataTextField = "CategoryDescription";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();


                SetReminderDataInGV();
            }

        }

        protected void gvAdjustmentVoucherDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                dt = ((DataTable)Session["NewAdjustmentDetailList"]);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[e.RowIndex].Delete();
                    Session["NewAdjustmentDetailList"] = dt;
                    BindData();
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        private void CreateDataTable()
        {
            if (Session["NewAdjustmentDetailList"] == null)
            {
                //CreateDataTable();
                Session["NewAdjustmentDetailList"] = new DataTable();
                DataColumn itemCode = new DataColumn("ItemCode", Type.GetType("System.String"));
                DataColumn itemDesc = new DataColumn("ItemDescription", Type.GetType("System.String"));
                DataColumn qty = new DataColumn("QtyAdjusted", Type.GetType("System.Int32"));
                DataColumn reason = new DataColumn("Reason", Type.GetType("System.String"));
                DataColumn price = new DataColumn("Value", Type.GetType("System.Decimal"));
                DataColumn amount = new DataColumn("TotalAmount", Type.GetType("System.Decimal"));

                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(itemCode);
                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(itemDesc);
                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(qty);
                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(price);
                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(reason);
                ((DataTable)Session["NewAdjustmentDetailList"]).Columns.Add(amount);
            }


        }

        private void SetReminderDataInGV()
        {
            dt = ((DataTable)Session["NewAdjustmentDetailList"]);

            List<Reminder> reminderList = reminderBl.getReminderForAdjustmentList();

            for (int i = 0; i < reminderList.Count(); i++)
            {
                dr = dt.NewRow();
                dr["ItemCode"] = reminderList[i].StationeryId;
                dr["ItemDescription"] = stationeryBl.getStationeryById(reminderList[i].StationeryId).Description;
                dr["QtyAdjusted"] = reminderList[i].Qty;
                dr["Value"] = stationeryBl.getStationeryById(reminderList[i].StationeryId).Price1;
                dr["Reason"] = reminderList[i].Reason;
                dr["TotalAmount"] = (stationeryBl.getStationeryById(reminderList[i].StationeryId).Price1) * (reminderList[i].Qty);
                dt.Rows.Add(dr);

            }
            Session["NewAdjustmentDetailList"] = dt;
            BindData();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = ddlCategory.SelectedItem.Value.ToString();

            ddlDescription.DataSource = stationeryBl.getAllStationeriesByCategory(int.Parse(ddlCategory.SelectedItem.Value));

            ddlDescription.DataTextField = "Description";
            ddlDescription.DataValueField = "StationeryId";
            ddlDescription.DataBind();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Employee emp = new Employee();
            //emp.EmployeeId = 4;
            //emp.DepartmentId = "STS";

            CreateNewAdjustmentVoucherBL createNewAdjustmentVoucherBl = new CreateNewAdjustmentVoucherBL();
            dt = (DataTable)Session["NewAdjustmentDetailList"];
            List<AdjustmentVoucherDetail> AVDlist = new List<AdjustmentVoucherDetail>();
            int qty = 0;
            string itemcode = "";
            string reason = "";

            for (int i = 0; i < gvAdjustmentVoucherDetail.Rows.Count; i++)
            {
                foreach (TableCell cell in gvAdjustmentVoucherDetail.Rows[i].Cells)
                {
                    TextBox t = (TextBox)cell.FindControl("txtReason");
                    reason = (t.Text);
                    itemcode = gvAdjustmentVoucherDetail.Rows[i].Cells[0].Text;
                    qty = Convert.ToInt32(gvAdjustmentVoucherDetail.Rows[i].Cells[2].Text);
                }
                AdjustmentVoucherDetail rd = new AdjustmentVoucherDetail() { StationeryId = itemcode, QtyAdjusted = qty, Reason = reason };

                //Set Adjustment Voucher Detail List
                AVDlist.Add(rd);
            }
            if (createNewAdjustmentVoucherBl.createNewAdjustmentVoucher(AVDlist, emp.EmployeeId))
            {
                reminderBl.updateReminder(reminderList);
                Session["NewAdjustmentDetailList"] = null;
                Response.Redirect("~/Store/StoreStaffMain.aspx");

            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                dt = ((DataTable)Session["NewAdjustmentDetailList"]);
                if (dt.Rows.Count > 0)
                {
                    dt.Clear();
                    Session["NewAdjustmentDetailList"] = dt;
                    BindData();
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

            dt = ((DataTable)Session["NewAdjustmentDetailList"]);
            foreach (DataRow r in dt.Rows)
            {
                if (r["ItemCode"].Equals(ddlDescription.SelectedValue) && r["Reason"].ToString() == txtReason.Text)
                {
                    // plus input Qty
                    int q = int.Parse(r["QtyAdjusted"].ToString());
                    q += int.Parse(txtQuantityAdjusted.Text);
                    r["QtyAdjusted"] = q.ToString();
                    Session["NewAdjustmentDetailList"] = dt;
                    BindData();
                    return;
                }
            }
            dr = dt.NewRow();
            Stationery selectedStationery = stationeryBl.getStationeryById(ddlDescription.SelectedItem.Value);
            dr["ItemCode"] = ddlDescription.SelectedItem.Value;
            dr["ItemDescription"] = ddlDescription.SelectedItem.Text;
            dr["QtyAdjusted"] = int.Parse(txtQuantityAdjusted.Text);
            dr["Reason"] = txtReason.Text;
            if (selectedStationery.Price1 != null)
            {
                dr["Value"] = selectedStationery.Price1;
                dr["TotalAmount"] = (selectedStationery.Price1) * (int.Parse(txtQuantityAdjusted.Text));

            }
            //insert fake data
            else
            {
                dr["Value"] = "1";
                dr["TotalAmount"] = 1 * (int.Parse(txtQuantityAdjusted.Text));
            }

            dt.Rows.Add(dr);
            Session["NewAdjustmentDetailList"] = dt;
            BindData();

        }

        void BindData()
        {
            gvAdjustmentVoucherDetail.DataSource = Session["NewAdjustmentDetailList"];
            gvAdjustmentVoucherDetail.DataBind();
        }


    }
}