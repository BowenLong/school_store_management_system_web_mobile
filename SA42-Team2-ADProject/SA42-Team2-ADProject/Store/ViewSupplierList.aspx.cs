using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.StoreHead;

namespace ADProject.Store
{
    public partial class ViewSupplierList : System.Web.UI.Page
    {
        ManageSupplierBL manageSupplierBl = new ManageSupplierBL();
        Employee emp = new Employee();

        void BindData()
        {
            gvSupplierList.DataSource = manageSupplierBl.getAllSupplier();
            gvSupplierList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            BindData();
        }
    }
}