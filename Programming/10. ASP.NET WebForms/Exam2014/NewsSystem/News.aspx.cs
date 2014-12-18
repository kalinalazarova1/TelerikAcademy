using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class News : System.Web.UI.Page
    {
        private NewsDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new NewsDbContext();
        }

        public IEnumerable<NewsSystem.Models.Article> ArticlesRepeater_GetData()
        {
            return db.Articles.OrderByDescending(a => a.Likes.Sum(l => l.Value)).Take(3).ToList();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> lvCategories_GetData()
        {
            return db.Categories.OrderBy(c => c.Name).AsQueryable();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
    }
}