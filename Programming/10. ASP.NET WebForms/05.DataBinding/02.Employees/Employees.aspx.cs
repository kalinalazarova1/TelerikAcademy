using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            var employees = db.Employees.Select(empl => new { Id = empl.EmployeeID, Name = empl.FirstName + " " + empl.LastName }).ToList();
            this.EmployeesGridView.DataSource = employees;
            this.EmployeesGridView.DataKeyNames = new string[] { "Id" };
            Page.DataBind();
        }
    }
}