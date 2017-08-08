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
    public partial class DepartmentHeadRequisitionDetail : System.Web.UI.Page
    {
        Employee emp = new Employee();
        ApproveRequisitionBL approvedRequest;
        static Requisition selectedRequisition ;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.DepartmentHead, Session);

            approvedRequest= new ApproveRequisitionBL(emp);
            
            if(!Page.IsPostBack)
            {
                selectedRequisition = (Requisition)Session["SelectedRequisition"];
                gvReguisitionDetail.DataSource = selectedRequisition.RequisitionDetails;
                gvReguisitionDetail.DataBind();
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            selectedRequisition = (Requisition)Session["SelectedRequisition"];
            if(selectedRequisition!=null)
            {
                if(approvedRequest.approveRequisition(selectedRequisition))
                {
                    //Response.Write("<script>alert('Approved successfully')</script>");
                    sendEmail.sendMailToEmployee(selectedRequisition);
                    Response.Redirect("DepartmentHeadRequisition.aspx");
                }
                else
                {
                    Response.Redirect("DeptHeadMain.aspx");
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
                    sendEmail.sendMailToEmployee(selectedRequisition);
                    //Response.Write("<script>alert('Rejected successfully')</script>");
                    Response.Redirect("DepartmentHeadRequisition.aspx");
                }
                else
                {
                    Response.Redirect("DeptHeadMain.aspx");
                    //Response.Write("<script>alert('Rejected Unsuccessful!')</script>");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeptHeadMain.aspx");
        }
    }
}