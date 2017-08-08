using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using BLL;
using BLL.DepartmentHead;

namespace ADProject
{
    public partial class DepartmentHeadRequisition : System.Web.UI.Page
    {
        Employee emp = new Employee();
        ApproveRequisitionBL approveReqBl;


        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.DepartmentHead, Session);

            approveReqBl = new ApproveRequisitionBL(emp);
            if (!Page.IsPostBack)
            {
                Session["RequisitionList"] = approveReqBl.getAllPendingRequisitions();
                if (((List<Requisition>)Session["RequisitionList"]).Count>0)
                {
                    gvRequisitionList.DataSource = (List<Requisition>)Session["RequisitionList"];
                    gvRequisitionList.DataBind();
                }
                else
                {
                    lblNoRequi.Text = "Sorry, There is no pending requisition!";
                }

            }


        }

        protected void gvRequisitionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonField")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvRequisitionList.Rows[index];

                Session["SelectedRequisition"] = ((List<Requisition>)Session["RequisitionList"])[index];

                Response.Redirect("DepartmentHeadRequisitionDetail.aspx");
            }

        }

    }
}