using _01.MenuControl.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.MenuControl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var links = new Link[] 
            {
                new Link(){ Title = "Student System", Url = "http://telerikacademy.com/"},
                new Link(){ Title = "Telerik Academy", Url = "http://academy.telerik.com/"},
                new Link(){ Title = "Academy Forum", Url = "http://forums.academy.telerik.com/"}
            };

            this.MainMenu.DataSource = links;
            this.MainMenu.Color = Color.White;
            this.MainMenu.BackgroundColor = Color.MidnightBlue;
            this.MainMenu.DataBind();
        }
    }
}