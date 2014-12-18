using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.RegistrationForm
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxRequired_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Accept.Checked;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            this.Page.Validate("LoginInfo");
            if (!this.Page.IsValid)
            {
                this.Msg.Text = "Login info is invalid.";
            }

            if (Page.IsValid)
            {
                Response.Redirect("~/Success.aspx");
            }
        }

        protected void SubmitAddress_Click(object sender, EventArgs e)
        {
            this.Page.Validate("AddressInfo");
            if (!this.Page.IsValid)
            {
                this.Msg.Text = "Address info is invalid.";
            }
            else
            {
                this.Msg.Text = "Address info is valid.";
            }
        }

        protected void SubmitPersonal_Click(object sender, EventArgs e)
        {
            this.Page.Validate("PersonalInfo");
            if (!this.Page.IsValid)
            {
                this.Msg.Text = "Personal info is invalid.";
            }
            else
            {
                this.Msg.Text = "Personal info is valid.";
            }
        }

    }
}