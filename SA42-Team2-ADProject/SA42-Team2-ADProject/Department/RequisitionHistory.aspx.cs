using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.DepartmentStaff;

namespace ADProject.Department
{
    public partial class RequisitionHistory : System.Web.UI.Page
    {
        ViewRequisitionHistoryBL viewRequisitionHistoryBl;
        Employee emp = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                emp = (Employee)Session["CurrentEmployee"];
                viewRequisitionHistoryBl = new ViewRequisitionHistoryBL(emp);
                gvList.DataSource = viewRequisitionHistoryBl.getRequisitionListByDateRange(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));
                gvList.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please choose date range.')", true);
            }

        }

    }
}