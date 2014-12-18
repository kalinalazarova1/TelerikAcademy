using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.AssemblyInfo
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var assemblyInfo = Assembly.GetExecutingAssembly();
            this.AssemblyInfo.InnerText = "Location: " + assemblyInfo.Location;
            this.HelloCodeBehind.InnerText = "Hello, ASP.NET from code behind";
        }
    }
}