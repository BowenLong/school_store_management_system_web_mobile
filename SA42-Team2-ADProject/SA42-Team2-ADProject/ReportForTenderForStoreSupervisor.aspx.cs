using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;
using ADProject.Data;
using BLL.StoreHead;

namespace ADProject
{
    public partial class ReportForTenderForStoreSupervisor : System.Web.UI.Page
    {
        ReportBL reportBl;
        ManageSupplierBL supplierBl = new ManageSupplierBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindSupplierList();
            }




        }

        private void LoadReport(string supplierName)
        {
            reportBl = new ReportBL();

            // insert fake Supplier;


            List<Stationery> StationeryList = reportBl.getTenderReportBySupplier(supplierName);
            dtsReport ds = new dtsReport();
            //ds = new UsageReportDS();
            DataTable t = ds.Tables.Add("TenderReport");

            t.Columns.Add("ItemDescription", Type.GetType("System.String"));
            t.Columns.Add("TenderPrice", Type.GetType("System.Decimal"));
            t.Columns.Add("UOM", Type.GetType("System.String"));
            DataRow r;

            foreach (Stationery s in StationeryList)
            {
                r = t.NewRow();
                r["ItemDescription"] = s.Description;
                r["TenderPrice"] = reportBl.getPriceBySupplierName(s, supplierName);
                r["UOM"] = s.UOM.UOMDescription;

                t.Rows.Add(r);
            }

            try
            {
                ReportForTender objRpt = new ReportForTender();
                objRpt.SetDataSource(t);
                Viewer.ReportSource = objRpt;
                Viewer.RefreshReport();

            }
            catch (Exception ex)
            {
                //throw ex.InnerException.InnerException;
            }
        }

        private void bindSupplierList()
        {
            this.ddlSupplier.DataSource = supplierBl.getAllSupplier();
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "SupplierId";
            this.ddlSupplier.DataBind();
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Supplier = ddlSupplier.SelectedItem.Value.ToString();
            LoadReport(Supplier);
        }
    }
}