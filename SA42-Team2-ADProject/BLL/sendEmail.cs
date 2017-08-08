
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using System.Net;
using System.Net.Mail;

namespace BLL
{
    public class sendEmail
    {
        public static string toEmail = "thinthinswe.7990@gmail.com";
        public static void sendMailToDH(Employee e,Requisition r,string status)  //Request To Approve
        {
            //"thinthinswe.7990@gmail.com", "magicmyo@gmail.com" ,lamchautuan93@gmail.com,lijianhuanmanson@gmail.com,bowenlong1992@gmail.com
            SmtpClient c = new SmtpClient();
            c.Host = "lynx.class.iss.nus.edu.sg";
            //MailMessage m = new MailMessage(e.Email,e.Department.Employee1.Email);            
            MailMessage m = new MailMessage("thinthinswe.7990@gmail.com", toEmail);            
            if(status==Util.RequisitionStatus.Pending.ToString())
            {
                m.Subject = "Request for Requisition Approved";
                m.Body = "Please click the link below to view and approve the requisition request!";
                m.IsBodyHtml = true;
                //m.Body += "<br> <a href='http://10.10.2.115/logicstationery/Department/DepartmentHeadRequisition.aspx'>Click Here to approve requisition</a>";
                m.Body += "<br> If you require any clarification, please reply to this email ";
                m.Body += e.Department.Employee1.Email;
                m.Body += "<br> Thank you.";
            }
            else if(status==Util.RequisitionStatus.Canceled.ToString())
            {
                m.Subject = "Request for Cancel Requisition";
                m.IsBodyHtml = true;
                m.Body = "Dear " + r.Employee.Department.Employee1.EmployeeName + " ,";
                m.Body += "<br> I wish to cancel my requisition request submitted on " + r.RequestDate.ToShortDateString();
                m.Body += "<br> My apologies for the inconvenience caused.";
                m.Body += "<br> Sincerely,";
                m.Body += "<br>" + r.Employee.EmployeeName;
            }
            c.Send(m);
        }

        public static void sendMailToEmployee(Requisition r)    //Reply for Approve or Reject
        {
            SmtpClient c = new SmtpClient();
            c.Host = "lynx.class.iss.nus.edu.sg";
            MailMessage m = new MailMessage("thinthinswe.7990@gmail.com", toEmail);
            m.Subject = "Reply on Requisition Request";
            m.Body = "Your request for requisition date " + r.RequestDate + " hase been " + r.Status;
            m.IsBodyHtml = true;
            m.Body += "<br> Thank You";
            c.Send(m);
        }

        public static void sendMailToEmployeeForDisbursement(DisbursementList d)    //Reply for Disbursement Item
        {
            DateTime disburseDate = DateTime.Parse(d.RetriveDate.ToString()).AddDays(7);
            SmtpClient c = new SmtpClient();
            c.Host = "lynx.class.iss.nus.edu.sg";
            MailMessage m = new MailMessage("thinthinswe.7990@gmail.com", toEmail);
            m.Subject = "Requisition items is ready for collection";
            m.Body = "Dear " + d.Department.Employee2.EmployeeName;
            m.IsBodyHtml = true;
            m.Body += "<br> Please proceed to your collection point on " + disburseDate + "to collect your requisition items";
            m.Body += "<br> To view details of your requisition items, please click on hyperlink below.";
            //m.Body += "<br> <a href='http://10.10.2.115/logicstationery/Department/DisbursementListing.aspx'>Click here to see for disbursement items</a>";
            m.Body += "<br> If you require any clarification, please reply to this email " + d.Department.Employee1.Email;
            m.Body += "<br> Thank you.";
            c.Send(m);
        }

        public static void sendMailToStoreForChangeCollection(Employee e)
        {
            SmtpClient c = new SmtpClient();
            c.Host = "lynx.class.iss.nus.edu.sg";
            MailMessage m = new MailMessage("thinthinswe.7990@gmail.com", toEmail);
            m.Subject = "Change Collection Point or Representative";            
            m.IsBodyHtml = true;
            m.Body = "Dear,";
            m.Body += "<br> I wish to change my department collection point and representative.";
            m.Body += "<br> My apologies for the inconvenience caused.";
            m.Body += "<br> Sincerely,";
            m.Body += "<br>" + e.EmployeeName;
            c.Send(m);
        }

    }
}
