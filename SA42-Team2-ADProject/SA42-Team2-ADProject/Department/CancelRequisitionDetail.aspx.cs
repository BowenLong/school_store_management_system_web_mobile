using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.DepartmentStaff;

namespace ADProject
{
    public partial class CancelRequisitionDetail : System.Web.UI.Page
    {
        Employee emp = new Employee();
        CancelRequisitionBL canceledRequest;
        static Requisition selectedRequisition;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.Employee, Session);
                       

            if (!Page.IsPostBack)
            {
                selectedRequisition = (Requisition)Session["SelectedCancelRequisition"];
                gvRequisitionDetail.DataSource = selectedRequisition.RequisitionDetails;
                gvRequisitionDetail.DataBind();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            canceledRequest = new CancelRequisitionBL();
            if (selectedRequisition != null)
            {
                if (canceledRequest.cancelRequisition(selectedRequisition))
                {
                    //Response.Write("<script>alert('Rejected successfully')</script>");
                    sendEmail.sendMailToDH(emp, selectedRequisition,Util.RequisitionStatus.Canceled.ToString());
                    Response.Redirect("CancelRequisition.aspx");
                }
                else
                {
                    //Response.Write("<script>alert('Canceled Unsuccessful!')</script>");
                    Response.Redirect("DeptStaffMain.aspx");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CancelRequisition.aspx");
        }
    }
}