using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace _02.Employees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            var id = int.Parse(Request.QueryString["id"]);
            this.EmployeeDetailView.DataSource = db.Employees.Where(em => em.EmployeeID == id).ToList();
            Page.DataBind();
        }
    }
}