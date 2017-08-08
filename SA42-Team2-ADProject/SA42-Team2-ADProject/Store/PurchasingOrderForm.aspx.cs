using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;
using BLL.StoreClerk;
using BLL.StoreHead;


namespace ADProject
{

    public partial class PurchasingOrderForm : System.Web.UI.Page
    {
        static List<Reminder> reminderList;
        Employee emp = new Employee();
        StationeryBL stationeryBl = new StationeryBL();
        ManageSupplierBL supplierBl = new ManageSupplierBL();
        ReminderBL reminderBl = new ReminderBL();
        CreateNewPurchasingOrderBL createNewPurchasingOrderBl;
        DataTable dt;
        DataRow dr;


        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);

            if (!Page.IsPostBack)
            {
                bindSupplierList();
                Session["NewPurchasingList"] = null;
                //Set GV Formate
                CreateDataTable();
                gvPurchasingOrder.DataSource = ((DataTable)Session["NewPurchasingList"]);
                gvPurchasingOrder.DataBind();


                stationeryBl = new StationeryBL();
                ddlCategory.DataSource = stationeryBl.getAllCategories();
                ddlCategory.DataTextField = "CategoryDescription";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();


                SetReminderDataInGV();
                //lbNowDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            }


            DAL.PurchasingOrder po = new DAL.PurchasingOrder();
            //lblPONumber.Text = po.POId.ToString();


        }

        private DAL.Stationery getSelectedStationery()
        {
            string stationeryId = (String)Session["selectedItemStationeryID"];
            if (stationeryId != null)
                return (stationeryBl.getStationeryById(stationeryId));
            else
            {
                return (stationeryBl.getStationeryById("E020"));
            }
        }

        private void bindSupplierList()
        {
            this.ddlSupplier.DataSource = supplierBl.getAllSupplier();
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "SupplierId";
            this.ddlSupplier.DataBind();
        }

        protected void gvPurchasingOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                dt = ((DataTable)Session["NewPurchasingList"]);
                if (dt.Rows.Count > 0)
                {
                    dt.Rows[e.RowIndex].Delete();
                    Session["NewPurchasingList"] = dt;
                    BindData();
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }


        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = ddlCategory.SelectedItem.Value.ToString();

            ddlDescription.DataSource = stationeryBl.getAllStationeriesByCategory(int.Parse(ddlCategory.SelectedItem.Value));

            ddlDescription.DataTextField = "Description";
            ddlDescription.DataValueField = "StationeryId";
            ddlDescription.DataBind();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            dt = ((DataTable)Session["NewPurchasingList"]);
            foreach (DataRow r in dt.Rows)
            {
                if (r["ItemCode"].Equals(ddlDescription.SelectedValue))
                {
                    int q = int.Parse(r["Qty"].ToString());
                    q += int.Parse(txtQuantity.Text);
                    r["Qty"] = q.ToString();
                    Session["NewPurchasingList"] = dt;
                    BindData();
                    return;
                }
            }
            dr = dt.NewRow();
            dr["ItemCode"] = ddlDescription.SelectedItem.Value;
            dr["ItemDescription"] = ddlDescription.SelectedItem.Text;
            dr["Qty"] = int.Parse(txtQuantity.Text);

            Stationery stationery = stationeryBl.getStationeryById(ddlDescription.SelectedItem.Value);
            //string selectedSupplier  = ddlSupplier.SelectedItem.Value;
            //if (selectedSupplier == stationery.Supplier1 || selectedSupplier == stationery.Supplier2 || selectedSupplier == stationery.Supplier3)
            //{


            //}
            if (stationery.Price1 != null)
            {
                dr["Price"] = stationery.Price1;
                dr["Amount"] = (stationery.Price1) * int.Parse(txtQuantity.Text);
            }
            else
            {
                dr["Price"] = 1;
                dr["Amount"] = 1 * int.Parse(txtQuantity.Text);
            }
            dr["UOM"] = stationery.UOM.UOMDescription;
            dt.Rows.Add(dr);

            Session["NewPurchasingList"] = dt;
            BindData();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            reminderBl = new ReminderBL();
            Employee emp = new Employee();
            emp.EmployeeId = 4;
            emp.DepartmentId = "STS";
            createNewPurchasingOrderBl = new CreateNewPurchasingOrderBL(emp);

            dt = (DataTable)Session["NewPurchasingList"];
            List<PurchasingOrderDetail> PODlist = new List<PurchasingOrderDetail>();
            int qty = 0;
            string itemcode = "";


            for (int i = 0; i < gvPurchasingOrder.Rows.Count; i++)
            {
                foreach (TableCell cell in gvPurchasingOrder.Rows[i].Cells)
                {
                    TextBox t = (TextBox)cell.FindControl("txtQty");
                    qty = Convert.ToInt32(t.Text);
                    itemcode = gvPurchasingOrder.Rows[i].Cells[0].Text;
                }
                PurchasingOrderDetail rd = new PurchasingOrderDetail() { StationeryId = itemcode, OrderQty = qty };
                
                //Set Purchasing Order Detail List
                PODlist.Add(rd);
            }

            // Set Supplier
            Supplier supplier = new Supplier();
            supplier = supplierBl.getSupplierById(ddlSupplier.SelectedItem.Value);

            //Set Delivery Date
            DateTime deliveryDate;
            if (txtDeliveryDate.Text == "")
            {
                deliveryDate = DateTime.Today.Date;

            }
            else
            {
                deliveryDate = DateTime.Parse(txtDeliveryDate.Text);
            }


            int newPONumber = createNewPurchasingOrderBl.createNewPurchasingOrder(PODlist, supplier, deliveryDate);
            if (newPONumber > 0 )
            {
                reminderBl.updateReminder(reminderList);
                Session["NewPurchasingList"] = null;
                Response.Redirect("~/Store/StoreStaffMain.aspx");

            }
        }

        private void CreateDataTable()
        {
            if (Session["NewPurchasingList"] == null)
            {
                //CreateDataTable();
                Session["NewPurchasingList"] = new DataTable();
                DataColumn itemCode = new DataColumn("ItemCode", Type.GetType("System.String"));
                DataColumn itemDesc = new DataColumn("ItemDescription", Type.GetType("System.String"));
                DataColumn qty = new DataColumn("Qty", Type.GetType("System.Int32"));
                DataColumn price = new DataColumn("Price", Type.GetType("System.Decimal"));
                DataColumn uom = new DataColumn("UOM", Type.GetType("System.String"));
                DataColumn amount = new DataColumn("Amount", Type.GetType("System.Decimal"));

                ((DataTable)Session["NewPurchasingList"]).Columns.Add(itemCode);
                ((DataTable)Session["NewPurchasingList"]).Columns.Add(itemDesc);
                ((DataTable)Session["NewPurchasingList"]).Columns.Add(qty);
                ((DataTable)Session["NewPurchasingList"]).Columns.Add(price);
                ((DataTable)Session["NewPurchasingList"]).Columns.Add(uom);
                ((DataTable)Session["NewPurchasingList"]).Columns.Add(amount);
            }


        }

        private void SetReminderDataInGV()
        {
            dt = ((DataTable)Session["NewPurchasingList"]);

            reminderList = reminderBl.getReminderForReorderList();

            for (int i = 0; i < reminderList.Count(); i++)
            {
                dr = dt.NewRow();
                dr["ItemCode"] = reminderList[i].StationeryId;
                dr["ItemDescription"] = stationeryBl.getStationeryById(reminderList[i].StationeryId).Description;
                dr["Qty"] = reminderList[i].Qty;
                dr["Price"] = (stationeryBl.getStationeryById(reminderList[i].StationeryId).Price1) == null ? 0 : stationeryBl.getStationeryById(reminderList[i].StationeryId).Price1;
                dr["UOM"] = stationeryBl.getStationeryById(reminderList[i].StationeryId).UOM.UOMDescription;
                dr["Amount"] = (Convert.ToInt32(dr["Qty"])) * (reminderList[i].Qty);
                dt.Rows.Add(dr);

            }
            Session["NewPurchasingList"] = dt;
            BindData();
        }

        void BindData()
        {
            gvPurchasingOrder.DataSource = Session["NewPurchasingList"];
            gvPurchasingOrder.DataBind();
        }



    }






}
