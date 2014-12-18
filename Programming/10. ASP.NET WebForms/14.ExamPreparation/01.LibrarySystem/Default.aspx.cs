using _01.LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<_01.LibrarySystem.Models.Category> lvCategories_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories.AsQueryable();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> lvBooks_GetData()
        {
            var db = new LibraryDbContext();
            return db.Books;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            var keyword = this.SearchWord.Text;
            Response.Redirect("~/Search.aspx?q=" + keyword);
        }

    }
}