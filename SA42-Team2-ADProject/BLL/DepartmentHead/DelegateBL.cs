using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.DepartmentHead
{
    public class DelegateBL
    {
        Entities ctx;

        public Employee getCurrentDelegate(int deptHeadId)
        {
            ctx = new Entities();
            EmployeeBL eBL = new EmployeeBL();
            return eBL.getEmployeeById(deptHeadId).Department.Employees.Where(x => x.IsDelegate == true).FirstOrDefault();
        }

        public bool cancelDelegate(int employeeId)
        {
            ctx = new Entities();
            bool isDelegate = ctx.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault().IsDelegate;
            if (isDelegate)
            {
                ctx.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault().IsDelegate = false;
            }
            return (ctx.SaveChanges() > 0);
        }

        public Employee setDelegate(int employeeId)
        {
            ctx = new Entities();
            Employee e = ctx.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            if (!e.IsDelegate)
            {
                e.IsDelegate = true;
            }
            if (ctx.SaveChanges() > 0)
            {
                return e;
            }
            else return null;
        }

        public List<Employee> getAllEmployeeByDeptHead(int depHeadtId)
        {
            EmployeeBL bl = new EmployeeBL();
            List<Employee> result = bl.getAllEmployeeByDeptHeadId(depHeadtId);
            Employee e = result.Where(x => x.EmployeeId == depHeadtId).First();
            result.Remove(e);
            return result;
        }
    }
}

