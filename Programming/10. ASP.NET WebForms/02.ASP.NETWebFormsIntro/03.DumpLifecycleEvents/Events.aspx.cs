using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.DumpLifecycleEvents
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "Page_PreInit invoked" + "<br/>";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "Page_Init invoked" + "<br/>";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "Page_Load invoked" + "<br/>";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "Page_PreRender invoked" + "<br/>";
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "ButtonOK_Init invoked" + "<br/>";
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "ButtonOK_Load invoked" + "<br/>";
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "ButtonOK_Click invoked" + "<br/>";
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            this.Result.InnerHtml += "ButtonOK_PreRender invoked" + "<br/>----------------------------------------<br/>";
        }
    }
}