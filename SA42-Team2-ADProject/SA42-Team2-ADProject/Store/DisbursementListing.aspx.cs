using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;

namespace ADProject.Store
{
    public partial class DisbursementListing : System.Web.UI.Page
    {
        ViewDisbursementHistoryBL viewDisbursementHistoryBl;
        Employee emp = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

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

                Session["SelectedStoreDisbursement"] = ((List<DisbursementList>)Session["StoreDisbursementList"])[index];

                Response.Redirect("DisbursementStatus.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                viewDisbursementHistoryBl = new ViewDisbursementHistoryBL();
                Session["StoreDisbursementList"] = viewDisbursementHistoryBl.getAllDisbursementListsByStore(emp.DepartmentId, DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
                gvList.DataSource = (List<DisbursementList>)Session["StoreDisbursementList"];
                gvList.DataBind();
            }
        }
    }
}