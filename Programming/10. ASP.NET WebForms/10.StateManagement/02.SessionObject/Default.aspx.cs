using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SessionObject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["info"] == null)
            {
                Session.Add("info", new List<string>());
            }
        }

        protected void SaveInfo_Click(object sender, EventArgs e)
        {
            var list = (List<string>)Session["info"];
            list.Add(this.TextInput.Text);
            this.TextInfo.Text = string.Empty;
            foreach (var item in list)
            {
                this.TextInfo.Text += "<br/>" + item;
            }

            this.TextInput.Text = string.Empty;
        }
    }
}