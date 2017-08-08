using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;

namespace ADProject
{
    public partial class DeptHead : System.Web.UI.MasterPage
    {
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            if(emp!=null)
            {
                lblUsername.Text = emp.EmployeeName;
                lblDeptName.Text = emp.Department.DepartmentName;
            }
                
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            WebUtil.logoutAccount(Response, Session);
        }
    }
}