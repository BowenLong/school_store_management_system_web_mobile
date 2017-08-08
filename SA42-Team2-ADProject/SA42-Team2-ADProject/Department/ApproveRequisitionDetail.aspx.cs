using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.DepartmentHead;

namespace ADProject.Department
{
    public partial class ApproveRequisitionDetail : System.Web.UI.Page
    {
        Employee emp = new Employee();
        ApproveRequisitionBL approvedRequest;
        Requisition selectedRequisition;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);

            approvedRequest = new ApproveRequisitionBL(emp);

            if (!Page.IsPostBack)
            {
                selectedRequisition = (Requisition)Session["SelectedApproveRequisitionByDelegate"];
                gvList.DataSource = selectedRequisition.RequisitionDetails;
                gvList.DataBind();
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            selectedRequisition = (Requisition)Session["SelectedApproveRequisitionByDelegate"];
            if (selectedRequisition != null)
            {
                if (approvedRequest.approveRequisition(selectedRequisition))
                {
                    //Response.Write("<script>alert('Approved successfully')</script>");
                    selectedRequisition.Status = Util.RequisitionStatus.Approved.ToString();
                    sendEmail.sendMailToEmployee(selectedRequisition);
                    Response.Redirect("ApproveRequisition.aspx");
                }
                else
                {
                    Response.Redirect("DeptStaffMain.aspx");
                    //Response.Write("<script>alert('Approved Unsuccessful!')</script>");
                }
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedRequisition != null)
            {
                if (approvedRequest.rejectRequisition(selectedRequisition))
                {
                    selectedRequisition.Status = Util.RequisitionStatus.Rejected.ToString();
                    //Response.Write("<script>alert('Rejected successfully')</script>");
                    sendEmail.sendMailToEmployee(selectedRequisition);
                    Response.Redirect("ApproveRequisition.aspx");
                }
                else
                {
                    Response.Redirect("DeptStaffMain.aspx");
                    //Response.Write("<script>alert('Rejected Unsuccessful!')</script>");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveRequisition.aspx");
        }
    }
}