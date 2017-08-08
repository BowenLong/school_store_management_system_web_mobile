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
    public partial class StoreManagerMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreManager, Session);
            if (emp != null)
                lblUsername.Text = emp.EmployeeName;
        }
    }
}