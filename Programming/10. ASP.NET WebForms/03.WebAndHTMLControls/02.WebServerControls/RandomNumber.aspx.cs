using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.WebServerControls
{
    public partial class RandomNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            try
            {
                var lower = int.Parse(this.Min.Text);
                var upper = int.Parse(this.Max.Text);
                if (lower > upper)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.GeneratedNumber.Text = "Generated Random: " + new Random().Next(lower, upper + 1).ToString();
            }
            catch (Exception)
            {
                this.GeneratedNumber.Text = "Invalid Input";
            }
        }

        
    }
}