using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;


namespace BLL
{
    public class LoginBL
    {
        Entities ctx;

        public bool checkLoginUser(string userName,string password)
        {
            ctx = new Entities();
            Login login = ctx.Logins.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (login == null)
                return false;
            else
                return true;
        }

        public Employee getLoginAccount(string userName, string password)
        {
            ctx = new Entities();
            Login l = ctx.Logins.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (l != null)
            {
                return ctx.Employees.Where(x => x.EmployeeId == l.EmployeeId).First();
            }
            else return null;
        }
    }
}
