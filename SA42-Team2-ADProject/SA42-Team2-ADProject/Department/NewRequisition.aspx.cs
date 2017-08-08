using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using BLL.DepartmentStaff;
using DAL;

namespace ADProject
{
    public partial class NewRequisition : System.Web.UI.Page
    {
        //   List<Category> list;
        Employee emp = new Employee();
        StationeryBL stationeryBl;
        CreateRequisitionBL createReqBl;
        sendEmail sendingEmail;
        DataTable dt;
        DataRow dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);

            btnSubmit.Enabled = false;
            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Today.Date.ToShortDateString();
                if (Session["NewRequistionList"] == null)
                {
                    //CreateDataTable();
                    Session["NewRequistionList"] = new DataTable();
                    DataColumn itemCode = new DataColumn("ItemCode", Type.GetType("System.String"));
                    DataColumn itemDesc = new DataColumn("ItemDescription", Type.GetType("System.String"));
                    DataColumn qty = new DataColumn("Qty", Type.GetType("System.Int32"));
                    ((DataTable)Session["NewRequistionList"]).Columns.Add(itemCode);
                    ((DataTable)Session["NewRequistionList"]).Columns.Add(itemDesc);
                    ((DataTable)Session["NewRequistionList"]).Columns.Add(qty);
                }

                BindData();

                //Bind to Category
                stationeryBl = new StationeryBL();
                ddlCategory.DataSource = stationeryBl.getAllCategories();
                ddlCategory.DataTextField = "CategoryDescription";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlItemDescription.DataSource = stationeryBl.getAllStationeriesByCategory(int.Parse(ddlCategory.SelectedItem.Value));
                ddlItemDescription.DataTextField = "Description";
                ddlItemDescription.DataValueField = "StationeryId";
                ddlItemDescription.DataBind();

            }


        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            dt = ((DataTable)Session["NewRequistionList"]);
            foreach (DataRow r in dt.Rows)
            {
                if (r["ItemCode"].Equals(ddlItemDescription.SelectedValue))
                {
                    int q = int.Parse(r["Qty"].ToString());
                    q += int.Parse(txtQuantity.Text);
                    r["Qty"] = q.ToString();
                    Session["NewRequistionList"] = dt;

                    BindData();
                    return;
                }

            }

            dr = dt.NewRow();
            dr["ItemCode"] = ddlItemDescription.SelectedItem.Value;
            dr["ItemDescription"] = ddlItemDescription.SelectedItem.Text;
            dr["Qty"] = txtQuantity.Text;
            dt.Rows.Add(dr);

            // ViewState["UserAllocationTable"] = UserAllocationTable;
            Session["NewRequistionList"] = dt;

            BindData();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationeryBl = new StationeryBL();
            ddlItemDescription.DataSource = stationeryBl.getAllStationeriesByCategory(int.Parse(ddlCategory.SelectedItem.Value));
            ddlItemDescription.DataTextField = "Description";
            ddlItemDescription.DataValueField = "StationeryId";
            ddlItemDescription.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            createReqBl = new CreateRequisitionBL(emp);
            dt = (DataTable)Session["NewRequistionList"];
            List<RequisitionDetail> list = new List<RequisitionDetail>();
            int qty=0;
            string itemcode = "";

            for (int i = 0; i < gvList.Rows.Count; i++)
            {
                foreach (TableCell cell in gvList.Rows[i].Cells)
                {
                    TextBox t = (TextBox)cell.FindControl("txtQty");
                    qty = Convert.ToInt32(t.Text);                    
                    itemcode = gvList.Rows[i].Cells[0].Text;
                }
                RequisitionDetail rd = new RequisitionDetail() { StationeryId = itemcode, Qty = qty};
                list.Add(rd);
            }
            if (createReqBl.createNewRequisition(list))
            {
                Session["NewRequistionList"] = null;
                sendEmail.sendMailToDH(emp,null,Util.RequisitionStatus.Pending.ToString());
                Response.Redirect("~/Department/DeptStaffMain.aspx");
            }
            else //Saving Error!!!!
            {

            }
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                dt = ((DataTable)Session["NewRequistionList"]);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[e.RowIndex].Delete();
                    Session["NewRequistionList"] = dt;
                    BindData();
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        void BindData()
        {
            gvList.DataSource = Session["NewRequistionList"];
            gvList.DataBind();
        }

    }
}