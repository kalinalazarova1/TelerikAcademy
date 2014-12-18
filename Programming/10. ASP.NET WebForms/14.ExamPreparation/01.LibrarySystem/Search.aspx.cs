using _01.LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var keyword = (string)Request.QueryString["q"];
            this.PageTitle.InnerHtml = "Search Results for Query \"<em>" + Server.HtmlEncode(keyword) + "</em>\"";
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable BooksSearchResults_GetData()
        {
            var db = new LibraryDbContext();
            var keyword = (string)Request.QueryString["q"];
            return db.Books.Where(b => b.Author.IndexOf(keyword) >= 0 || b.Title.IndexOf(keyword) >= 0);
        }
    }
}