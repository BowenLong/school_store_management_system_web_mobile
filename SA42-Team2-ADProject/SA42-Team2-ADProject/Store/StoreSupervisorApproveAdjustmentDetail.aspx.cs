using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.StoreHead;

namespace ADProject.Store
{
    public partial class StoreSupervisorApproveAdjustmentDetail : System.Web.UI.Page
    {
        Employee emp = new Employee();
        InformAdjustmentBL informAdjBl;
        IssueAdjustmentVoucherBL issueAdjBl;
        static AdjustmentVoucher selectedVoucher;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreSupervisor, Session);

            informAdjBl = new InformAdjustmentBL(emp);

            if (!Page.IsPostBack)
            {
                selectedVoucher = (AdjustmentVoucher)Session["SelectedAdjustmentBySupervisor"];
                gvReguisitionDetail.DataSource = selectedVoucher.AdjustmentVoucherDetails;
                gvReguisitionDetail.DataBind();
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            issueAdjBl = new IssueAdjustmentVoucherBL(emp);
            selectedVoucher = (AdjustmentVoucher)Session["SelectedAdjustmentBySupervisor"];
            if (selectedVoucher != null)
            {
                if (issueAdjBl.updateAdjustmentVoucherToApprove(selectedVoucher, Util.AdjustmentStatus.Approved.ToString()))
                {
                    //Response.Write("<script>alert('Approved successfully')</script>");
                    Response.Redirect("ApproveAdjustment.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Approved Unsuccessful!')</script>");
                }
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            issueAdjBl = new IssueAdjustmentVoucherBL(emp);
            selectedVoucher = (AdjustmentVoucher)Session["SelectedAdjustmentBySupervisor"];
            if (selectedVoucher != null)
            {
                if (issueAdjBl.updateAdjustmentVoucherToApprove(selectedVoucher, Util.AdjustmentStatus.Canceled.ToString()))
                {
                    //Response.Write("<script>alert('Approved successfully')</script>");
                    Response.Redirect("ApproveAdjustment.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Approved Unsuccessful!')</script>");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreSupervisorApproveAdjustment.aspx");
        }
    }
}