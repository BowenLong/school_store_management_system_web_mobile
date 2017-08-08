using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using BLL;
using BLL.StoreHead;

namespace ADProject.Store
{
    public partial class ApproveAdjustment : System.Web.UI.Page
    {
        Employee emp = new Employee();
        InformAdjustmentBL informAdjustmentBl;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreManager, Session);

            informAdjustmentBl = new InformAdjustmentBL(emp);

            if (!Page.IsPostBack)
            {
                Session["ApproveAdjListByManager"] = informAdjustmentBl.getAdjustmentVoucherToApproved();
                gvList.DataSource = (List<AdjustmentVoucher>)Session["ApproveAdjListByManager"];
                gvList.DataBind();
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonField")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvList.Rows[index];

                Session["SelectedAdjustmentByManager"] = ((List<AdjustmentVoucher>)Session["ApproveAdjListByManager"])[index];

                Response.Redirect("ApproveAdjustmentDetail.aspx");
            }

        }

    }
}