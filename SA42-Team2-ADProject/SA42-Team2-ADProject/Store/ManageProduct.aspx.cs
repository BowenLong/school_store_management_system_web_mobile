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
using System.Reflection;

namespace ADProject.Store
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        StationeryBL stationeryBl = new StationeryBL();
        ManageSupplierBL supplierBl = new ManageSupplierBL();
        public static bool edit = false;
        Employee emp = new Employee();

        void BindData()
        {
            gvList.DataSource = stationeryBl.getAllStationeries();
            gvList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            if (!Page.IsPostBack)
            {
                BindData();

                ddlSearchCategory.DataSource = stationeryBl.getAllCategories();
                ddlSearchCategory.DataTextField = "CategoryDescription";
                ddlSearchCategory.DataValueField = "CategoryId";
                ddlSearchCategory.DataBind();
            }

            

            ddlCategory.DataSource = stationeryBl.getAllCategories();
            ddlCategory.DataTextField = "CategoryDescription";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();

            ddlUnitMeasure.DataSource = stationeryBl.getAllUnitOfMeasure();
            ddlUnitMeasure.DataTextField = "UOMDescription";
            ddlUnitMeasure.DataValueField = "UOMId";
            ddlUnitMeasure.DataBind();

            ddlBin.DataSource = stationeryBl.getAllBin();
            ddlBin.DataTextField = "Bin";
            ddlBin.DataValueField = "Bin";
            ddlBin.DataBind();

            ddl1stSupplier.DataSource = supplierBl.getAllSupplier();
            ddl1stSupplier.DataTextField = "SupplierName";
            ddl1stSupplier.DataValueField = "SupplierId";
            ddl1stSupplier.DataBind();

            ddl2ndSupplier.DataSource = supplierBl.getAllSupplier();
            ddl2ndSupplier.DataTextField = "SupplierName";
            ddl2ndSupplier.DataValueField = "SupplierId";
            ddl2ndSupplier.DataBind();

            ddl3rdSupplier.DataSource = supplierBl.getAllSupplier();
            ddl3rdSupplier.DataTextField = "SupplierName";
            ddl3rdSupplier.DataValueField = "SupplierId";
            ddl3rdSupplier.DataBind();
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Stationery toCheck = stationeryBl.getStationeryById(txtItemId.Text);
            if (edit == false)
            {
                if (toCheck == null)
                {
                    
                    Stationery toAdd = new Stationery();
                    toAdd.StationeryId = txtItemId.Text;
                    toAdd.Description = txtDescription.Text;
                    toAdd.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                    toAdd.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                    toAdd.ReorderQuantity = Convert.ToInt32(txtReorderQty.Text);
                    toAdd.UOMId = Convert.ToInt32(ddlUnitMeasure.SelectedValue.ToString());
                    toAdd.Bin = ddlBin.SelectedValue;
                    toAdd.Supplier1 = ddl1stSupplier.SelectedValue;
                    toAdd.Supplier2 = ddl2ndSupplier.SelectedValue;
                    toAdd.Supplier3 = ddl3rdSupplier.SelectedValue;
                    toAdd.Price1 = Convert.ToDecimal(txtPrice1.Text);
                    toAdd.Price2 = Convert.ToDecimal(txtPrice2.Text);
                    toAdd.Price3 = Convert.ToDecimal(txtPrice3.Text);
                    toAdd.EstimatedBalance = 0;
                    
                    if (stationeryBl.createNewStationery(toAdd))
                    {
                        //Response.Write("<script>alert('Data inserted successfully')</script>");
                        Response.Redirect("StoreStaffMain.aspx");
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
                toCheck.Description = txtDescription.Text;
                toCheck.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                toCheck.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
                toCheck.ReorderQuantity = Convert.ToInt32(txtReorderQty.Text);
                toCheck.UOMId = Convert.ToInt32(ddlUnitMeasure.SelectedValue.ToString());
                toCheck.Bin = ddlBin.SelectedValue;
                toCheck.Supplier1 = ddl1stSupplier.SelectedValue;
                toCheck.Supplier2 = ddl2ndSupplier.SelectedValue;
                toCheck.Supplier3 = ddl3rdSupplier.SelectedValue;
                toCheck.Price1 = Convert.ToDecimal(txtPrice1.Text);
                toCheck.Price2 = Convert.ToDecimal(txtPrice2.Text);
                toCheck.Price3 = Convert.ToDecimal(txtPrice3.Text);
                //gvList.EditIndex = -1;
                if (stationeryBl.updateStationery(toCheck))
                {
                    Response.Write("<script>alert('Data updated successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Updating Error!')</script>");
                }
            }

        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["Id"].ToString();
            //if (e.CommandName == "Edit")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = gvList.Rows[index];

            //    txtItemId.Text = row.Cells[0].Text;
            //    ddlCategory.SelectedItem.Text = row.Cells[1].Text;
            //    txtDescription.Text = row.Cells[2].Text;
            //    ddlUnitMeasure.SelectedItem.Text = row.Cells[3].Text;
            //    ddlBin.SelectedItem.Text = row.Cells[4].Text;
            //    txtReorderLevel.Text = row.Cells[5].Text;
            //    txtReorderQty.Text = row.Cells[6].Text;
            //    ddl1stSupplier.SelectedItem.Text = row.Cells[7].Text;
            //    ddl2ndSupplier.SelectedItem.Text = row.Cells[8].Text;
            //    ddl3rdSupplier.SelectedItem.Text = row.Cells[9].Text;
            //    txtPrice1.Text = row.Cells[10].Text;
            //    txtPrice2.Text = row.Cells[11].Text;
            //    txtPrice3.Text = row.Cells[12].Text;
            //    edit = true;
            //    return;
            //    //txtr.Text = row.Cells[2].Text;
            //}
        }


        //protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{

        //    gvList.UpdateRow(e.RowIndex, false);
        //}

        //protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            edit = true;
            Stationery toShowForEdit = stationeryBl.getStationeryById(ddlSearchItemCode.SelectedValue);
            txtItemId.Text = toShowForEdit.StationeryId;
            ddlCategory.SelectedValue = toShowForEdit.CategoryId.ToString();
            txtDescription.Text = toShowForEdit.Description;
            ddlUnitMeasure.SelectedValue = toShowForEdit.UOMId.ToString();
            ddlBin.SelectedValue = toShowForEdit.Bin.ToString();
            txtReorderLevel.Text = toShowForEdit.ReorderLevel.ToString();
            txtReorderQty.Text = toShowForEdit.ReorderQuantity.ToString();
            ddl1stSupplier.SelectedValue = toShowForEdit.Supplier1.ToString() == null ? "" : toShowForEdit.Supplier1.ToString();
            ddl2ndSupplier.SelectedValue = toShowForEdit.Supplier2.ToString() == null ? "" : toShowForEdit.Supplier2.ToString();
            ddl3rdSupplier.SelectedValue = toShowForEdit.Supplier3.ToString() == null ? "" : toShowForEdit.Supplier3.ToString();
            txtPrice1.Text = toShowForEdit.Price1.ToString();
            txtPrice2.Text = toShowForEdit.Price2.ToString();
            txtPrice3.Text = toShowForEdit.Price3.ToString();

        }

        protected void ddlSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            stationeryBl = new StationeryBL();
            ddlSearchItemCode.DataSource = stationeryBl.getAllStationeriesByCategory(int.Parse(ddlSearchCategory.SelectedItem.Value));
            ddlSearchItemCode.DataTextField = "Description";
            ddlSearchItemCode.DataValueField = "StationeryId";
            ddlSearchItemCode.DataBind();
        }


    }
}