using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Hello
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnSayHello_Click(object sender, EventArgs e)
        {
            var name = this.Name.Text;
            if (!string.IsNullOrEmpty(name))
            {
                this.Greeting.Text = "Hello, " + HttpUtility.HtmlEncode(name) + "!";
            }
        }
    }
}