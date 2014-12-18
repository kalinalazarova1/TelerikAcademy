using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.RegistrationForm
{
    public partial class RegForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] univercities = { "UNSS", "SU", "TU" };
            string[] specialties = { "Computer Systems", "Software Engineering", "Business Informatics" };
            string[] allCourses = { "ASP.NET", "OOP", "DSA", "Databases" };
            this.Uni.DataSource = univercities;
            this.Spec.DataSource = specialties;
            this.SelectedCourses.Items.AddRange(allCourses.Select(c => new ListItem(c)).ToArray());
            Page.DataBind();
        }

        protected void OnSubmit_Click(object sender, EventArgs e)
        {
            this.Form.Visible = false;
            this.Content.InnerHtml = "<h1>" + Server.HtmlEncode(this.FirstName.Text) + " " + Server.HtmlEncode(this.LastName.Text) + "</h1>";
            this.Content.InnerHtml += "<h2>Faculty Number: " + Server.HtmlEncode(this.FacultyNumber.Text) + "</h2>";
            this.Content.InnerHtml += "<p>University: " + this.Uni.SelectedValue + "</p>";
            this.Content.InnerHtml += "<p>Specialty: " + this.Spec.SelectedValue + "</p>";
            this.Content.InnerHtml += "<ul>Courses:";
            var selected = this.SelectedCourses.Items.Cast<ListItem>().Where(c => c.Selected);
            foreach (var item in selected)
            {
                this.Content.InnerHtml += "<li>" + item + "</li>";
            }

            this.Content.InnerHtml += "</ul>";
        }
    }
}