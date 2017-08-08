using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.StoreClerk;

namespace ADProject.Store
{
    public partial class ManageStock : System.Web.UI.Page
    {
        StationeryBL stationeryBl;
        static int categoryId = 0;
        Employee emp = new Employee();
        void BindData()
        {
            Session["SelectedStationery"] = null;
            Session["ManageStationeryList"] = stationeryBl.getAllStationeriesByCategory(Convert.ToInt32(ddlCategory.SelectedValue));
            gvStock.DataSource = (List<Stationery>)Session["ManageStationeryList"]; ;
            gvStock.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             stationeryBl = new StationeryBL();
             emp = (Employee)Session["CurrentEmployee"];
             WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            if (!Page.IsPostBack)
            {
                ddlCategory.DataSource = stationeryBl.getAllCategories();
                ddlCategory.DataTextField = "CategoryDescription";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();

                BindData();
            }

        }

        protected void gvStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonField")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvStock.Rows[index];

                Session["SelectedStationery"] = ((List<Stationery>)Session["ManageStationeryList"])[index];

                Response.Redirect("StockCard.aspx");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}