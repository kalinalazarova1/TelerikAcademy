using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class ArticlesDetails : System.Web.UI.Page
    {
        private NewsDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new NewsDbContext();
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article ArticleFormView_GetItem([QueryString("Id")]int? id)
        {
            if(id == null)
            {
                Response.Redirect("~/");
            }

            return db.Articles.FirstOrDefault(b => b.Id == id);
        }
    }
}