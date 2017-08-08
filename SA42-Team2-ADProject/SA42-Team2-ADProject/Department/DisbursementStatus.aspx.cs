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
    public partial class DisbursementStatus : System.Web.UI.Page
    {
        ViewDisbursementHistoryBL viewDisbursementHistoryBl;
        DisbursementList selectedDepartmentDisbursement = null;
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);

            viewDisbursementHistoryBl = new ViewDisbursementHistoryBL();
            if (!Page.IsPostBack)
            {
                selectedDepartmentDisbursement = (DisbursementList)Session["SelectedDepartmentDisbursement"];
                lblCollectionPoint.Text = selectedDepartmentDisbursement.Department.CollectionPoint.CollectionPointName;
                lblRepresentative.Text = selectedDepartmentDisbursement.Department.Employee.EmployeeName;
                imgSignature.ImageUrl = selectedDepartmentDisbursement.SignatureURL.ToString().Trim() + ".png";
                gvDisbursementStatus.DataSource = selectedDepartmentDisbursement.DisbursementListDetails;
                gvDisbursementStatus.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisbursementListing.aspx");
        }


    }
}
