using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.EmployeesWithFormView
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
                var db = new NorthwindEntities();
                var employees = db.Employees.Select(empl => new { Id = empl.EmployeeID, Name = empl.FirstName + " " + empl.LastName }).ToList();
                this.EmployeesGridView.DataSource = employees;
                this.EmployeesGridView.DataKeyNames = new string[] { "Id" };
                if (Request.QueryString["id"] != null)
                {
                    var id = int.Parse(Request.QueryString["id"]);
                    this.EmployeeFormView.DataSource = db.Employees.Where(em => em.EmployeeID == id).ToList();
                }

                Page.DataBind();
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            this.EmployeeFormView.ChangeMode(FormViewMode.Edit);
            this.MultiViewButtons.SetActiveView(this.ViewEditMode);
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            this.EmployeeFormView.ChangeMode(FormViewMode.ReadOnly);
            this.MultiViewButtons.SetActiveView(this.ViewNormalMode);
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            var db = new NorthwindEntities();
            this.EmployeeFormView.ChangeMode(FormViewMode.ReadOnly);
            this.MultiViewButtons.SetActiveView(this.ViewNormalMode);
            int employeeIndex = int.Parse(Request.QueryString["id"]);
            var currentEmployee = db.Employees.First(em => em.EmployeeID == employeeIndex);
            TextBox homePhoneTextBox = (TextBox)this.EmployeeFormView.FindControl("HomePhoneTextBox");
            currentEmployee.HomePhone = homePhoneTextBox.Text;
            TextBox notesTextBox = (TextBox)this.EmployeeFormView.FindControl("NotesTextBox");
            currentEmployee.Notes = notesTextBox.Text;
            db.SaveChanges();
        }
    }
}