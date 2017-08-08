using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CollectionPointAndRepresentativeBL
    {
        public static List<CollectionPoint> getAllCollectionPoints()
        {
            Entities ctx = new Entities();
            return ctx.CollectionPoints.ToList();
        }

        public static CollectionPoint getCurrentCollectionPoint(int employeeId)
        {
            Entities ctx = new Entities();
            return ctx.CollectionPoints.Where(x => x.CollectionPointID == ctx.Employees.Where(y => y.EmployeeId == employeeId).FirstOrDefault().Department.CollectionPointId).FirstOrDefault();
        }

        public static bool updateCollectionPoint(int collectionPointId, int employeeId)
        {
            Entities ctx = new Entities();
            ctx.Employees.Where(x => x.EmployeeId == employeeId).First().Department.CollectionPointId = collectionPointId;
            return (ctx.SaveChanges() > 0);
        }

        public static Employee getRepresentativeByDeptHeadId(string deptHeadId)
        {
            EmployeeBL bl = new EmployeeBL();
            Department d = bl.getEmployeeById(int.Parse(deptHeadId)).Department;

            return bl.getEmployeeById(d.RepresentativeId ?? default(int));
        }
        public static Employee getRepresentativeByDept(string deptId)
        {
            Entities ctx = new Entities();
            return ctx.Employees.Where(x => x.EmployeeId == (ctx.Departments.Where(y => y.DepartmentId == deptId).FirstOrDefault().RepresentativeId)).FirstOrDefault();
        }
        
        public static Employee setRep(int employeeId)
        {
            Entities ctx = new Entities();
            Employee e = ctx.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            if (e == null)
            {
                return null;
            }
            if (e.Department.RepresentativeId == employeeId)
            {
                return null;
            }
            else
            {
                e.Department.RepresentativeId = employeeId;
            }
            if (ctx.SaveChanges() > 0)
            {
                return e;
            }
            else return null;
        }

    }
}