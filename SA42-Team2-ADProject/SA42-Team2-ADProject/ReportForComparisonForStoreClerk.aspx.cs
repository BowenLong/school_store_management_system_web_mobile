using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using System.Data;
using ADProject.Data;

namespace ADProject
{
    public partial class ReportForComparisonForStoreClerk : System.Web.UI.Page
    {
        StationeryBL stationeryBl = new StationeryBL();
        EmployeeBL empBl = new EmployeeBL();
        List<Category> catList = new List<Category>();
        List<DAL.Department> deptList = new List<DAL.Department>();
        List<int> yList = new List<int>() { 2010,2011,2012,2013,2014,2015,2016};
        List<int> mList = new List<int>() { 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12 };
        ReportBL reportBl = new ReportBL();
        dtsReport ds = new dtsReport();

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {
                //stationeryBl = new StationeryBL();
                //ddlCategory.DataSource = stationeryBl.getAllCategories();
                //ddlCategory.DataTextField = "CategoryDescription";
                //ddlCategory.DataValueField = "CategoryId";
                //ddlCategory.DataBind();

                //empBl = new EmployeeBL();
                //ddlDepartment.DataSource = empBl.getAllDepartment();
                //ddlDepartment.DataTextField = "CategoryDescription";
                //ddlDepartment.DataValueField = "CategoryId";
                //ddlDepartment.DataBind();
            }
        }

        protected void btnAddStationery_Click(object sender, EventArgs e)
        {
            //catList.Add(ddlCategory.SelectedValue);

            LoadReport();
        }

        void LoadReport()
        {
            //reportBl = new ReportBL();

            //catList = stationeryBl.getAllCategories();
            //deptList = empBl.getAllDepartment();
            //List<List<Report>> stationeryList = reportBl.getTrendAnalysisReport(deptList, catList, mList, yList);


            //DataTable t = ds.Tables.Add("InventoryStatusReport");
            //t.Columns.Add("ItemCode", Type.GetType("System.String"));
            //t.Columns.Add("Description", Type.GetType("System.String"));
            //t.Columns.Add("Location", Type.GetType("System.String"));
            //t.Columns.Add("UOM", Type.GetType("System.String"));
            //t.Columns.Add("Balance", Type.GetType("System.Int32"));
            //t.Columns.Add("ReorderLevel", Type.GetType("System.Int32"));

            //DataRow r;

            //foreach (List<Report> stationery in stationeryList)
            //{
            //    r = t.NewRow();
            //    r["ItemCode"] = stationery.StationeryId;
            //    r["Description"] = stationery.Description;
            //    r["Location"] = stationery.Bin;
            //    r["UOM"] = stationery.UOM.UOMDescription;
            //    r["Balance"] = stationery.StationeryTransactions.Last().Balance;
            //    r["ReorderLevel"] = stationery.ReorderLevel;
            //    t.Rows.Add(r);
            //}

            //ReportForInventoryStatus objRpt = new ReportForInventoryStatus();
            //int i = t.Rows.Count;
            //objRpt.SetDataSource(t);

            //// Entities ctx = new Entities();
            //// List<Report> rpt = ctx.Reports.ToList();

            //// dtsReport ds = new dtsReport();

            //// DataTable t = ds.Tables.Add("TrendAnalysis");
            //// t.Columns.Add("DepartmentName", Type.GetType("System.String"));
            //// t.Columns.Add("Description", Type.GetType("System.String"));
            //// t.Columns.Add("Date", Type.GetType("System.String"));
            //// t.Columns.Add("Qty", Type.GetType("System.String"));
            //// t.Columns.Add("Test", Type.GetType("System.String"));

            //// DataRow r;

            //// foreach (Report stationery in rpt)
            //// {
            ////     r = t.NewRow();
            ////     r["DepartmentName"] = stationery.DepartmentName;
            ////     r["Description"] = stationery.Description;
            ////     r["Date"] = stationery.Date;
            ////     r["Qty"] = stationery.Qty;
            ////     r["Test"] = stationery.Test;
            ////     t.Rows.Add(r);
            //// }

            //// TrendAnalysis objRpt = new TrendAnalysis();
            //// int i = t.Rows.Count;
            //// objRpt.SetDataSource(t);

            //ViewerForStoreClerk.ReportSource = objRpt;
            //ViewerForStoreClerk.RefreshReport();
        }

    }
}