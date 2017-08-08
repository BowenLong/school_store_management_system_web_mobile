using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace ADProject.Department
{
    public partial class DisbursementListing : System.Web.UI.Page
    {
        ViewDisbursementHistoryBL viewDisbursementHistoryBl;
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);

            //txtFromDate.Text = System.DateTime.Today.ToShortDateString();
            //txtToDate.Text = System.DateTime.Today.AddDays(7).ToShortDateString();

            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonField")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvList.Rows[index];

                Session["SelectedDepartmentDisbursement"] = ((List<DisbursementList>)Session["DepartmentDisbursementList"])[index];

                Response.Redirect("DisbursementStatus.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                viewDisbursementHistoryBl = new ViewDisbursementHistoryBL();
                Session["DepartmentDisbursementList"] = viewDisbursementHistoryBl.getAllDisbursementListsByDepartment(emp.DepartmentId, DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
                gvList.DataSource = (List<DisbursementList>)Session["DepartmentDisbursementList"];
                gvList.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose date range.')", true);
            }

        }


    }
}