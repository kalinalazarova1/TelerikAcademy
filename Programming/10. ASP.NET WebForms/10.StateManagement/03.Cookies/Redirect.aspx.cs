﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Cookies
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["MyCookie"];
            if (cookie != null)
            {
                this.Info.Text = cookie.Value;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}