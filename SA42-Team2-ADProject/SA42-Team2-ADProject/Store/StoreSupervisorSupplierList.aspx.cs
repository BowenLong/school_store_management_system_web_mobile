using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DAL;
using BLL;
using BLL.StoreHead;

namespace ADProject.Store
{
    public partial class StoreSupervisorSupplierList : System.Web.UI.Page
    {
        StationeryBL stationeryBl;
        ManageSupplierBL manageSupplierBl = new ManageSupplierBL();
        public static bool edit = false;
        Employee emp = new Employee();
        DataTable dt;
        DataRow dr;

        void BindData()
        {
            gvList.DataSource = manageSupplierBl.getAllSupplier();
            gvList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreSupervisor, Session);

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Supplier toCheck = manageSupplierBl.getSupplierById(txtSupplierCode.Text);
            if (edit == false)
            {
                if (toCheck == null)
                {
                    Supplier toAdd = new Supplier();
                    toAdd.SupplierId = txtSupplierCode.Text;
                    toAdd.SupplierName = txtSupplierName.Text;
                    toAdd.ContactName = txtContactName.Text;
                    toAdd.Phone_No = txtPhoneNo.Text;
                    toAdd.Fax_No = txtFaxNo.Text;
                    toAdd.GST_Registration_No = txtGSTRegistrationNo.Text;
                    toAdd.Address = txtAddress.Text;

                    if (manageSupplierBl.createNewSupplier(toAdd))
                    {
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Saving Error!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Item already exist!')</script>");
                }
            }
            else
            {
                toCheck.SupplierName = txtSupplierName.Text;
                toCheck.ContactName = txtContactName.Text;
                toCheck.Phone_No = txtPhoneNo.Text;
                toCheck.Fax_No = txtFaxNo.Text;
                toCheck.GST_Registration_No = txtGSTRegistrationNo.Text;
                toCheck.Address = txtAddress.Text;
                //gvList.EditIndex = -1;
                if (manageSupplierBl.updateSupplier(toCheck))
                {
                    Response.Write("<script>alert('Data updated successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Updating Error!')</script>");
                }
            }
            BindData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreSupervisorMain.aspx");
        }

    }
}