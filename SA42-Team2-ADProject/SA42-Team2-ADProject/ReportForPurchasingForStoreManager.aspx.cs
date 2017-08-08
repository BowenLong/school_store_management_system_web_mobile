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


namespace ADProject
{
    public partial class ReportForPurchasingForStoreManager : System.Web.UI.Page
    {
        ReportBL reportBl;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadReport(DateTime fromDate, DateTime toDate)
        {
            reportBl = new ReportBL();


            List<PurchasingOrder> poList = reportBl.getPurchaseOrderReport(fromDate, toDate);
            dtsReport ds = new dtsReport();
            //ds = new UsageReportDS();
            DataTable t = ds.Tables.Add("PurchaseOrderReport");
            t.Columns.Add("No", Type.GetType("System.String"));
            t.Columns.Add("ItemCode", Type.GetType("System.String"));
            t.Columns.Add("Description", Type.GetType("System.String"));
            t.Columns.Add("OrderQty", Type.GetType("System.Int32"));
            t.Columns.Add("ReceivedQty", Type.GetType("System.Int32"));
            t.Columns.Add("SupplierName", Type.GetType("System.String"));
            DataRow r;

            foreach (PurchasingOrder po in poList)
            {
                List<PurchasingOrderDetail> detailInpo = po.PurchasingOrderDetails.ToList();
                foreach (PurchasingOrderDetail poDetail in detailInpo)
                {
                    r = t.NewRow();
                    r["No"] = po.POId;
                    r["SupplierName"] = po.Supplier.SupplierName;
                    r["ItemCode"] = poDetail.StationeryId;
                    r["Description"] = poDetail.Stationery.Description;
                    r["OrderQty"] = poDetail.OrderQty;
                    r["ReceivedQty"] = poDetail.ReceivedQty;
                    t.Rows.Add(r);
                }
            }

            try
            {
                ReportForPurchasing objRpt = new ReportForPurchasing();
                int i = t.Rows.Count;
                objRpt.SetDataSource(t);

                Viewer.ReportSource = objRpt;
                Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                //throw ex.InnerException.InnerException;
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.Parse(txtFromDate.Text);
            DateTime ToDate = DateTime.Parse(txtToDate.Text);
            LoadReport(FromDate, ToDate);
        }
    }
}