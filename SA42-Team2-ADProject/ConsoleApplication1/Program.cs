using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DepartmentHead;
using DAL;
using BLL.StoreHead;
using BLL.StoreClerk;
using BLL.DepartmentStaff;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ViewRequisitionHistoryBL a = new ViewRequisitionHistoryBL();
            Entities ctx = new Entities();

            //AdjustmentVoucherDetail avd = new AdjustmentVoucherDetail() { Stationery = ctx.Stationeries.Where(x => x.StationeryId.Equals("C001")).First(), QtyAdjusted = -30 };
            //Console.WriteLine(avd.Value.ToString());
            //Console.Read();
            //ctx.Stationeries.Where(x => x.StationeryTransactions.Count == 0).ToList().ForEach(y => y.StationeryTransactions.Add(new StationeryTransaction()
            //{
            //    TransactionDate = DateTime.Today.Date,
            //    Balance = 0,
            //    TransactionQuantity = 0
            //}));
            //Console.Write(ctx.SaveChanges());
            //Console.Read();

            ////Console.WriteLine(ctx.Employees.ToList().ToString());
            //Employee deptHead = ctx.Employees.Where(x => x.EmployeeId == 36).First();
            //ApproveRequisitionBL bl = new ApproveRequisitionBL(deptHead);
            //Requisition r = bl.getRequisitionById(5);
            //bl.approveRequisition(r);          

            //AdjustmentVoucher
            //AdjustmentVoucherDetail avd = new AdjustmentVoucherDetail();
            //avd.StationeryId = "C004";
            //avd.QtyAdjusted = -25;
            //avd.Reason = "Damaged";
            //avd.Value = 180;

            //AdjustmentVoucherDetail avd1 = new AdjustmentVoucherDetail();
            //avd1.StationeryId = "C003";
            //avd1.QtyAdjusted = -25;
            //avd1.Reason = "Damaged";
            //avd1.Value = 210;

            //List<AdjustmentVoucherDetail> avdList = new List<AdjustmentVoucherDetail>();
            //avdList.AddRange(new[] { avd, avd1 });
            //CreateNewAdjustmentVoucherBL bl = new CreateNewAdjustmentVoucherBL();
            //bl.createNewAdjustmentVoucher(avdList,1);

            //Viewing Stock Card
            //StationeryBL bl = new StationeryBL();
            //Stationery s = ctx.Stationeries.First();
            //Console.WriteLine(s.StationeryId);
            //string s1 = bl.getStockCardForStationery(s, new DateTime(2016, 09, 01), new DateTime(2016, 09, 15)).First().ToString();
            //Console.WriteLine(s1);
            //Console.Read();

            // ctx = new Entities();
            //List<Department> dList = ctx.Departments.Where(x => x.DepartmentId.Equals("ENGL") || x.DepartmentId.Equals("CPSC")).ToList();
            //List<Category> cList = ctx.Categories.Where(x => x.CategoryId == 1 || x.CategoryId == 4 || x.CategoryId == 5).ToList();
            //List<String> dateList = new List<String>();
            //dateList.Add("7-2016");
            //dateList.Add("8-2016");
            //dateList.Add("9-2016");
            //ReportBL l = new ReportBL();
            //List<int> month = new List<int>();
            //month.AddRange(new int[]{7,8,9});
            //List<int> year = new List<int>();
            //year.Add(2016);
            //List<Object> o = l.getTrendAnalysisReport(dList, cList, month,year);
            //List<Report> reports = new List<Report>();
            //foreach(Object obj in o){
            //    reports = (List<Report>) obj;
            //    reports.ForEach(x => Console.WriteLine(x.ToString()));
                
            //}
            //Console.Read();

            InformAdjustmentBL bl = new InformAdjustmentBL(new Employee() { EmployeeId = 4,RoleId=3 });
            Console.Write(bl.getAdjustmentVoucherToApproved().First().AdjustmentVoucherDetails.First().Value);




        }
    }
}
