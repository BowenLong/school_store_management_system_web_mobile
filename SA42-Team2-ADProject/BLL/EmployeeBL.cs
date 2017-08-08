using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EmployeeBL
    {
        Entities ctx;
        
        public List<Department> getAllDepartment()
        {
            ctx = new Entities();
            return ctx.Departments.ToList();
        }

        public Employee getEmployeeById(int id)
        {
            ctx = new Entities();
            return ctx.Employees.Where(x => x.EmployeeId == id).First();
        }

        public List<Employee> getEmployeeListByDepartment(string departmentId)
        {
            ctx = new Entities();
            return ctx.Employees.Where(x => x.DepartmentId == departmentId).ToList();
        }

        //public List<Employee> getEmployeeListByDepartmentForDelegateList(string departmentId)
        //{
        //    ctx = new Entities();
        //    return ctx.Employees.Where(x => x.DepartmentId == departmentId).ToList().ForEach(y=>y.EmployeeId != )
        //}

        public List<Employee> getAllEmployeeByDeptHeadId(int id)
        {
            ctx = new Entities();
            return ctx.Employees.Where(x => x.EmployeeId == id).FirstOrDefault().Department.Employees.OrderBy(y => y.EmployeeName).ToList();
        }
    }
}
