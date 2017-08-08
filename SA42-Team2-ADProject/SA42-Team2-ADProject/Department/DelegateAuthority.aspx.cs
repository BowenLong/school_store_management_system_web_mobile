using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using DAL;
using BLL.DepartmentHead;

namespace ADProject.Department
{
    public partial class DelegateAuthority : System.Web.UI.Page
    {
        static Employee emp = new Employee();
        EmployeeBL employeeBl;
        DelegateBL delegateBl;
        static Employee delegateEmployee=new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.DepartmentHead, Session);

            
            if(!Page.IsPostBack)
            {
                delegateBl = new DelegateBL();
                employeeBl = new EmployeeBL();
                delegateEmployee = delegateBl.getCurrentDelegate(Convert.ToInt32(emp.Department.HeadId));
                if (delegateEmployee != null)
                {
                    btnDelegate.Enabled = true;
                    //ddlToWhom.DataSource = employeeBl.getEmployeeListByDepartment(emp.DepartmentId);
                    ddlToWhom.DataSource = delegateBl.getAllEmployeeByDeptHead(Convert.ToInt32(emp.Department.HeadId));
                    ddlToWhom.DataTextField = "EmployeeName";
                    ddlToWhom.DataValueField = "EmployeeId";
                    ddlToWhom.DataBind();
                    ddlToWhom.SelectedValue = delegateEmployee.EmployeeId.ToString();
                }
                else
                {
                    btnDelegate.Enabled = false;
                    ddlToWhom.DataSource = delegateBl.getAllEmployeeByDeptHead(Convert.ToInt32(emp.Department.HeadId));
                    //ddlToWhom.DataSource = employeeBl.getEmployeeListByDepartment(emp.DepartmentId);
                    ddlToWhom.DataTextField = "EmployeeName";
                    ddlToWhom.DataValueField = "EmployeeId";
                    ddlToWhom.DataBind();
                }
            }
            //ddlToWhom.DataSource = employeeBl.getEmployeeListByDepartment(emp.DepartmentId);
            //ddlToWhom.DataTextField = "EmployeeName";
            //ddlToWhom.DataValueField = "EmployeeId";
            //ddlToWhom.DataBind();

            //Employee delegater = delegateBl.getCurrentDelegate(emp.DepartmentId);
            //ddlToWhom.SelectedIndex = -1;
        }

        protected void ddlToWhom_DataBound(object sender, EventArgs e)
        {
            ddlToWhom.Items.Insert(0, new ListItem("--Select Employee--", "0"));
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            delegateBl = new DelegateBL();
            if(ddlToWhom.SelectedValue!=0.ToString())
            {
                delegateBl.cancelDelegate(delegateEmployee.EmployeeId);
                Response.Redirect("DeptHeadMain.aspx");
            }            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeptHeadMain.aspx");
        }

        protected void ddlToWhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            delegateBl = new DelegateBL();
            if(ddlToWhom.SelectedValue!=0.ToString())
            {
                if(delegateEmployee!=null)
                    delegateBl.cancelDelegate(delegateEmployee.EmployeeId);
                delegateBl.setDelegate(Convert.ToInt32(ddlToWhom.SelectedValue));

                Response.Redirect("DeptHeadMain.aspx");
            }

        }
    }
}