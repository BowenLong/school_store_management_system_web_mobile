using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreClerk
{
    public  class CreateNewPurchasingOrderBL
    {
        Entities ctx;
        Employee e;

        public CreateNewPurchasingOrderBL(Employee e)
        {
            this.e = e;
        }

        public int createNewPurchasingOrder(List<PurchasingOrderDetail> podList, Supplier s,DateTime expectedDeliveryDate)
        {
            ctx = new Entities();
            PurchasingOrder po = new PurchasingOrder();
            po.SupplierId = s.SupplierId;
            po.OrderDate = DateTime.Today;
            po.EmployeeId = e.EmployeeId;
            po.PurchasingOrderDetails = podList;
            po.ExpectedDeliveryDate = expectedDeliveryDate;
            ctx.PurchasingOrders.Add(po);
            ctx.SaveChanges();
            return po.POId;
        }
    }
}
