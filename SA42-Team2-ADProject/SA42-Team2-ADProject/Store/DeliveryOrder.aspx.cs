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
    public partial class DeliveryOrder : System.Web.UI.Page
    {
        private static int poNumber = 0;
        Employee emp = new Employee();
        ReceiveDeliveryOrderBL receiveDeliveryOrderBl = new ReceiveDeliveryOrderBL();
        private static PurchasingOrder forGrid = new PurchasingOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.StoreClerk, Session);            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            poNumber = Convert.ToInt32(txtPONumber.Text);
            forGrid = receiveDeliveryOrderBl.getPurchasingOrderByPOId(poNumber);
            if(forGrid!=null)
            {
                lblSupplier.Text = forGrid.Supplier.SupplierName;
                
                gvList.DataSource = receiveDeliveryOrderBl.getPurchasingOrderByPOId(poNumber).PurchasingOrderDetails;
                gvList.DataBind();
                lblError.Text ="";

            }
            else //Show Error Label There is no purchase voucher!!
            {
                lblError.Text = "There is no data for that PO Number!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            List<PurchasingOrderDetail> list = forGrid.PurchasingOrderDetails.ToList();            

            for (int i = 0; i < gvList.Rows.Count; i++)
            {
                foreach (TableCell cell in gvList.Rows[i].Cells)
                {
                    if(list[i].StationeryId==gvList.Rows[i].Cells[0].Text)
                    {
                        TextBox t = (TextBox)cell.FindControl("txtQty");
                        TextBox r = (TextBox)cell.FindControl("txtRemark");
                        list[i].ReceivedQty = Convert.ToInt32(t.Text);
                        list[i].Remarks = r.Text;
                    }                    
                }
                
                //RequisitionDetail rd = new RequisitionDetail() { StationeryId = itemcode, Qty = qty };
                //list.Add(rd);
            }
            forGrid.PurchasingOrderDetails = list;
            DateTime deliveryDate;
            if (txtDeliveryDate.Text == "")
            {
                deliveryDate = DateTime.Today.Date;

            }
            else
            {
                deliveryDate = DateTime.Parse(txtDeliveryDate.Text);
            }
            forGrid.DeliveryDate =deliveryDate;
            if(receiveDeliveryOrderBl.receiveDeliveryOrder(forGrid))
            {
                Response.Redirect("StoreStaffMain.aspx");
            }            
        }
    }
}