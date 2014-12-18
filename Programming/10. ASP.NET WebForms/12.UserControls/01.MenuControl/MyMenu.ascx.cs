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
    public partial class MyMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Color Color 
        {
            get
            {
                return (Color)this.DataListId.ForeColor;
            }
            set
            {
                this.DataListId.ForeColor = value;
            }
        }

        public Color BackgroundColor 
        {
            get
            {
                return (Color)this.DataListId.BackColor;
            }
            set
            {
                this.DataListId.BackColor = value;
            }
        }

        public IList<Link> DataSource 
        {
            get
            {
                return (List<Link>)this.DataListId.DataSource;
            }
            set
            {
                this.DataListId.DataSource = value;
            }
        }
    }
}