using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.DepartmentStaff;


namespace ADProject
{
    public partial class CancelRequisition : System.Web.UI.Page
    {
        Employee emp = new Employee();
        ViewRequisitionHistoryBL viewRequisitionHistoryBl;

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtFromDate.Text!="" && txtToDate.Text!="")
            {
                emp = (Employee)Session["CurrentEmployee"];
                viewRequisitionHistoryBl = new ViewRequisitionHistoryBL(emp);
                Session["CancelRequisitionList"] = viewRequisitionHistoryBl.getPendingRequisitionListByDateRange(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
                gvRequisitionList.DataSource = (List<Requisition>)Session["CancelRequisitionList"];
                gvRequisitionList.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose date range.')", true);
            }
            
        }

        protected void gvRequisitionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonField")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvRequisitionList.Rows[index];

                Session["SelectedCancelRequisition"] = ((List<Requisition>)Session["CancelRequisitionList"])[index];

                Response.Redirect("CancelRequisitionDetail.aspx");
            }

        }
    }
}