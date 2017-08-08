using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DAL;

namespace ADProject
{
    public class WebUtil
    {
        public static void checkRoleDept(HttpResponse Response, Employee emp, BLL.Util.Roles role, HttpSessionState Session)
        {
            emp = (Employee)Session["CurrentEmployee"];
            if (emp != null)
            {
                int r = (int)role;
                if (emp.RoleId != r)
                {
                    Response.Redirect("~/LoginForm.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginForm.aspx");
            }
        }

        public static void logoutAccount(HttpResponse Response, HttpSessionState Session)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("~/LoginForm.aspx");
        }
    }
}