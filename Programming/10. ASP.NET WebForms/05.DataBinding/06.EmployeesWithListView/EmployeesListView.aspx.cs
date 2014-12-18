using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.EmployeesWithListView
{
    public partial class EmployeesListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            this.EmployeesDataListView.DataSource = db.Employees.ToList();
            Page.DataBind();
        }
    }
}