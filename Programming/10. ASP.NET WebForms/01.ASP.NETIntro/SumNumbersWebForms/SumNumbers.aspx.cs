using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SumNumbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SumButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sum.Text = (double.Parse(this.first.Text) + double.Parse(this.second.Text)).ToString();
            }
            catch (Exception)
            {
                this.sum.Text = "Invalid input";
            }
        }
    }
}