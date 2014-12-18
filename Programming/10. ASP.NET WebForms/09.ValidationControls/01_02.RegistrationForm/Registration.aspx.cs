using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_02.RegistrationForm
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
            if (Page.IsValid)
            {
                Response.Redirect("~/Success.aspx");
            }
        }

    }
}