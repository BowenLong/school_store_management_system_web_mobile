using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using ADProject.Data;
using System.Data;

namespace ADProject
{
    public partial class ReportForInventoryStatusForStoreSupervisor : System.Web.UI.Page
    {
        ReportBL reportBl;
        StationeryBL stationeryBl;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                stationeryBl = new StationeryBL();
                ddlCategory.DataSource = stationeryBl.getAllCategories();
                ddlCategory.DataTextField = "CategoryDescription";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();

            }
        }


        void LoadReport(int categoryId)
        {
            reportBl = new ReportBL();


            List<Stationery> stationeryList = reportBl.getInventoryStatusReportByCategory(categoryId);
            dtsReport ds = new dtsReport();

            DataTable t = ds.Tables.Add("InventoryStatusReport");
            t.Columns.Add("ItemCode", Type.GetType("System.String"));
            t.Columns.Add("Description", Type.GetType("System.String"));
            t.Columns.Add("Location", Type.GetType("System.String"));
            t.Columns.Add("UOM", Type.GetType("System.String"));
            t.Columns.Add("Balance", Type.GetType("System.Int32"));
            t.Columns.Add("ReorderLevel", Type.GetType("System.Int32"));

            DataRow r;

            foreach (Stationery stationery in stationeryList)
            {
                r = t.NewRow();
                r["ItemCode"] = stationery.StationeryId;
                r["Description"] = stationery.Description;
                r["Location"] = stationery.Bin;
                r["UOM"] = stationery.UOM.UOMDescription;
                r["Balance"] = stationery.StationeryTransactions.Last().Balance;
                r["ReorderLevel"] = stationery.ReorderLevel;
                t.Rows.Add(r);
            }

            ReportForInventoryStatus objRpt = new ReportForInventoryStatus();
            int i = t.Rows.Count;
            objRpt.SetDataSource(t);


            ViewerForStoreClerk.ReportSource = objRpt;
            ViewerForStoreClerk.RefreshReport();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            LoadReport(categoryId);

        }



    }
}