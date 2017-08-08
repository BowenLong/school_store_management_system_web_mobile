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
    public partial class StockCard : System.Web.UI.Page
    {
        StationeryBL stationeryBl;
        static Stationery selectedStationery;
        Employee emp = new Employee();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            if (!Page.IsPostBack)
            {
                selectedStationery = (Stationery)Session["SelectedStationery"];

                lblItemCode.Text = selectedStationery.StationeryId;
                lblItemDescription.Text = selectedStationery.Description;
                lblBin.Text = selectedStationery.Bin;
                lblUOM.Text = selectedStationery.UOM.UOMDescription;
                lbl1stSupplier.Text = (selectedStationery.Supplier == null) ? "" : selectedStationery.Supplier.SupplierName;
                lbl2ndSupplier.Text = (selectedStationery.Supplier4 == null) ? "" : selectedStationery.Supplier4.SupplierName;
                lbl3rdSupplier.Text = (selectedStationery.Supplier5 == null) ? "" : selectedStationery.Supplier5.SupplierName;

                gvStockCardDetail.DataSource = selectedStationery.StationeryTransactions;
                gvStockCardDetail.DataBind();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void gvStockCardDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStockCardDetail.PageIndex = e.NewPageIndex;
            BindData();
        }

        void BindData()
        {
            stationeryBl = new StationeryBL();
            gvStockCardDetail.DataSource = stationeryBl.getStockCardForStationery(selectedStationery, DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text));            
            gvStockCardDetail.DataBind();
        }
    }
}