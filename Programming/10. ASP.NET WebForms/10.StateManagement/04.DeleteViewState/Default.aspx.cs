using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sumbit_Click(object sender, EventArgs e)
        {
            this.Result.Text = this.Test.Text;
            Page.DataBind();
        }

        protected void DeleteVS_Click(object sender, EventArgs e)
        {
            this.Result.Text = this.Test.Text;
            Page.DataBind();
        }
    }
}