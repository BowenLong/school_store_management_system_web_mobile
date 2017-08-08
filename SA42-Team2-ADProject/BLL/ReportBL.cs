using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class ReportBL
    {
        Entities ctx;
        public List<PurchasingOrder> getPurchaseOrderReport(DateTime fromDate,DateTime toDate)
        {
            ctx = new Entities();
            return ctx.PurchasingOrders.Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate).ToList();
        }


        public List<Stationery> getInventoryStatusReportByCategory(Int32 CategoryId)
        {
            ctx = new Entities();
            return ctx.Stationeries.Where(x => x.CategoryId == CategoryId).ToList();
        }


        public List<Stationery> getTenderReportBySupplier(String SupplierName)
        {
            ctx = new Entities();
            return ctx.Stationeries.Where(x => x.Supplier1 == SupplierName || x.Supplier2 == SupplierName || x.Supplier3 == SupplierName).ToList();
        }


        public Decimal getPriceBySupplierName( Stationery stationery ,String SupplierName)
        {      
            if (stationery.Supplier1 == SupplierName)
            {
                return (Decimal)stationery.Price1;
            }

            if (stationery.Supplier2 == SupplierName)
            {
                return (Decimal)stationery.Price2;
            }
            else
            {
                return (Decimal)stationery.Price3;
            }

        }

        public List<List<Report>> getTrendAnalysisReport(List<Department> departmentList, List<Category> categoryList, List<int> month, List<int> year)
        {

            List<List<Report>> result = new List<List<Report>>();
            ctx = new Entities();

            foreach (int i in year)
            {
                foreach (int j in month)
                {
                    List<Report> reportList = new List<Report>();
                    foreach (Category c in categoryList)
                    {
                        if (departmentList != null)
                        {
                            foreach (Department d in departmentList)
                            {

                                Report r = ctx.Reports.AsNoTracking().Where(x => x.Month == j && x.Year == i && x.CategoryId == c.CategoryId && x.DepartmentId.Equals(d.DepartmentId)).FirstOrDefault();
                                if (r != null)
                                {
                                    reportList.Add(r);
                                }
                            }
                        }
                        else
                        {

                            List<Report> fromDB = ctx.Reports.AsNoTracking().Where(x => x.Month == j && x.Year == i && x.CategoryId == c.CategoryId).ToList();

                            if (fromDB.Count > 0)
                            {
                                Report r = new Report() { CategoryDescription = c.CategoryDescription, CategoryId = c.CategoryId, Month = j, Year = i, Total = 0 };
                                fromDB.ForEach(x => r.Total += x.Total);
                                reportList.Add(r);
                            }
                        }
                    }
                    result.Add(reportList);
                }
            }
            return result;
        }
    }
}
