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
    public partial class LoginForm : System.Web.UI.Page
    {
        LoginBL loginBl;
        DAL.Login login;
        static Employee emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];

            if (emp != null)
                RedirectPage(emp);

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginBl = new LoginBL();

            if(txtUserName.Text!="" && txtPassword.Text!="")
            {
                if (loginBl.checkLoginUser(txtUserName.Text, txtPassword.Text))
                {
                    emp = loginBl.getLoginAccount(txtUserName.Text, txtPassword.Text);
                    Session["CurrentEmployee"] = emp;

                    RedirectPage(emp);
                }                    

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username or password is not corrrect')", true);
            }
        }

        void RedirectPage(Employee e)
        {
            if (e.RoleId == (int)Util.Roles.Employee) //1
                Response.Redirect("~/Department/DeptStaffMain.aspx");
            else if (e.RoleId == (int)Util.Roles.DepartmentHead) //5
                Response.Redirect("~/Department/DeptHeadMain.aspx");
            else if (e.RoleId == (int)Util.Roles.StoreClerk) //2
                Response.Redirect("~/Store/StoreStaffMain.aspx");
            else if (e.RoleId == (int)Util.Roles.StoreSupervisor) //3
                Response.Redirect("~/Store/StoreSupervisorMain.aspx");
            else if (e.RoleId == (int)Util.Roles.StoreManager) //4
                Response.Redirect("~/Store/StoreManagerMain.aspx");
        }
    }
}