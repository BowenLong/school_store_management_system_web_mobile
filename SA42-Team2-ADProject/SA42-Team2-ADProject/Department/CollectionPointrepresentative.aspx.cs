using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;
using BLL.DepartmentHead;

namespace ADProject.Department
{
    public partial class CollectionPointrepresentative : System.Web.UI.Page
    {
        Employee emp = new Employee();
        static EmployeeBL employeeBl = new EmployeeBL();
        CollectionPoint currentCollectionPt = new CollectionPoint();
        Employee currentRepresentative = new Employee();
        static bool changeRepresentative = false, changeCollectionPt = false;
        static int collectionpt, representativeId;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            emp = (Employee)Session["CurrentEmployee"];
            WebUtil.checkRoleDept(Response, emp, Util.Roles.DepartmentHead, Session);
            //ChangeRepresentativeAndCollectionPointBL changeCollectionPointAndRepresentativeBl = new ChangeRepresentativeAndCollectionPointBL(emp);
            //CollectionPointAndRepresentativeBL collectionAndRepresentativeBl = new CollectionPointAndRepresentativeBL();

            if (!Page.IsPostBack)
            {
                currentCollectionPt = CollectionPointAndRepresentativeBL.getCurrentCollectionPoint(emp.EmployeeId);
                currentRepresentative = CollectionPointAndRepresentativeBL.getRepresentativeByDept(emp.DepartmentId);

                if(currentCollectionPt!= null && currentRepresentative!=null)
                {
                    txtRepresentative.Text = currentRepresentative.EmployeeName;
                    txtCurrentCollection.Text = currentCollectionPt.CollectionPointName;
                }

                ddlRepresentative.DataSource = employeeBl.getEmployeeListByDepartment(emp.DepartmentId);
                ddlRepresentative.DataTextField = "EmployeeName";
                ddlRepresentative.DataValueField = "EmployeeId";
                ddlRepresentative.DataBind();
                ddlRepresentative.SelectedValue = currentRepresentative.EmployeeId.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         
            if(changeCollectionPt==true)
            {
                CollectionPointAndRepresentativeBL.updateCollectionPoint(collectionpt, emp.EmployeeId);
            }

            if(changeRepresentative==true)
            {
                CollectionPointAndRepresentativeBL.setRep(representativeId);
            }
            sendEmail.sendMailToStoreForChangeCollection(emp);
            Response.Redirect("DeptHeadMain.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            changeCollectionPt = false;
            changeRepresentative = false;
            Response.Redirect("DeptHeadMain.aspx");
        }

        protected void rblCollectionPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCollectionPt = true;
             collectionpt = Convert.ToInt32(rblCollectionPoint.SelectedValue);   
        }

        protected void ddlRepresentative_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeRepresentative = true;
            representativeId = Convert.ToInt32(ddlRepresentative.SelectedValue);
        }
    }
}