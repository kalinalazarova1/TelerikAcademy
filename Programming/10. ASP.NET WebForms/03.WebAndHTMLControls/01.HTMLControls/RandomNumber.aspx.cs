using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.HTMLControls
{
    public partial class RandomNumber : System.Web.UI.Page
    {
        Random ran = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnGenerate_ServerClick(object sender, EventArgs e)        
        {
            try
            {
                var lower = int.Parse(this.Min.Value);
                var upper = int.Parse(this.Max.Value);
                if (lower > upper)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.RamdomNumber.InnerText = ran.Next(lower, upper + 1).ToString();
            }
            catch (Exception)
            {
                this.RamdomNumber.InnerText = "Invalid input";
            }          
        }


    }
}