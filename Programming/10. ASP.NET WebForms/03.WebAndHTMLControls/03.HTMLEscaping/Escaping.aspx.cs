using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.HTMLEscaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnProcessInput_Click(object sender, EventArgs e)
        {
            var text = this.Origin.Text;
            this.ResultLabel.Text = "In label: " + Server.HtmlEncode(text);
            this.Result.Text = "In text box: " + text;
        }
    }
}