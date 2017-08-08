using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.StoreClerk;

using DAL;

namespace ADProject
{
    public partial class _Default : Page
    {

        Entities ctx;
        List<BinForRetrieval> binList;
        protected void Page_Load(object sender, EventArgs e)
        {
            RetrievalListBL rBL = new RetrievalListBL();
            ctx = new Entities();

           //binList = rBL.getRetrievalList("Pending");
          // GridView1.DataSource = binList;
          //GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    GridView child = (GridView) e.Row.FindControl("stationery");
        //    child.DataSource = binList[e.Row.RowIndex].Stationeries.ToList();
        //    child.DataBind();
        //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //RetrievalListBL bl = new RetrievalListBL();
            //DropDownList1.DataSource = bl.getRetrievalListByDateRange(new DateTime(2016, 09, 07), new DateTime(2016, 09, 14));
            //DropDownList1.DataBind();

            DisburseStationeryBL bl = new DisburseStationeryBL();
            //DropDownList1.DataSource = bl.getCollectionPointList();
            //DropDownList1.DataTextField = "CollectionPointName";
            //DropDownList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          //  RetrievalListBL bl = new RetrievalListBL();
          //  GridView1.DataSource = bl.getRetrievalList(DateTime.Parse(DropDownList1.SelectedValue));
          //GridView1.DataBind();
            
            DisburseStationeryBL bl = new DisburseStationeryBL();
            //DisbursementList dl = bl.getDisbursementListForDepartment(new Department() { DepartmentId = TextBox1.Text });
            //dl.DisbursementListDetails.ToList().ForEach(x => x.ReceivedQty = x.GivenQty);
            //bl.confirmDisbursementList(dl);
        }

    }
}