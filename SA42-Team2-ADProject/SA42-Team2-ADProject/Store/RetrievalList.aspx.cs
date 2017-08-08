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
    public partial class RetrievalList : System.Web.UI.Page
    {
        Entities ctx;
        RetrievalListBL rBL;
        List<BinForRetrieval> binList;
        Employee emp = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            rBL = new RetrievalListBL();
            if(!Page.IsPostBack)
            {
                ddlRetrievalDate.DataSource = rBL.getRetrievalListByDateRange(new DateTime(2016, 09, 01), new DateTime(2016, 09, 30));
                ddlRetrievalDate.DataBind();
            }

        }

        void BindData()
        {
            rBL = new RetrievalListBL();
            gvRetrievalList.DataSource = rBL.getRetrievalList(DateTime.Parse(ddlRetrievalDate.SelectedItem.Text));
            gvRetrievalList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();             
        }
        
        protected void gvRetrievalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRetrievalList.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}