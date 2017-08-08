using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.StoreHead
{
    public class ManageSupplierBL
    {
        Entities ctx;

        public List<Supplier> getAllSupplier()
        {
            ctx = new Entities();
            return ctx.Suppliers.ToList();
        }

        public Supplier getSupplierById(string supplierId)
        {
            ctx = new Entities();
            return ctx.Suppliers.Where(x => x.SupplierId == supplierId).First();
        }

        public bool createNewSupplier(Supplier s)
        {
            ctx = new Entities();

            Supplier toAdd = new Supplier();
            toAdd.SupplierId = s.SupplierId;
            toAdd.SupplierName = s.SupplierName;
            toAdd.ContactName = s.ContactName;
            toAdd.GST_Registration_No = s.GST_Registration_No;
            toAdd.Phone_No = s.Phone_No;
            toAdd.Fax_No = s.Fax_No;
            toAdd.Address = s.Address;
            ctx.Suppliers.Add(toAdd);
            return (ctx.SaveChanges() > 0);
        }

        public bool updateSupplier(Supplier s)
        {
            ctx = new Entities();
            Supplier toUpdate = ctx.Suppliers.Where(x => x.SupplierId == s.SupplierId).First();
            toUpdate.SupplierName = s.SupplierName;
            toUpdate.ContactName = s.ContactName;
            toUpdate.GST_Registration_No = s.GST_Registration_No;
            toUpdate.Phone_No = s.Phone_No;
            toUpdate.Fax_No = s.Fax_No;
            toUpdate.Address = s.Address;
            return (ctx.SaveChanges() > 0);
        }
    }
}
