using _01.LibrarySystem.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
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
        public IQueryable<Book> BooksListView_GetData()
        {
            var db = new LibraryDbContext();

            return db.Books.OrderBy(b => b.Id).Include(b => b.Category);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BooksListView_DeleteItem(int Id)
        {
            var db = new LibraryDbContext();
            var selected = db.Books.Find(Id);
            db.Books.Remove(selected);
            db.SaveChanges();
        }

        public void BooksListView_InsertItem()
        {
            var item = new Book();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();
                db.Books.Add(item);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void BooksListView_UpdateItem(int Id)
        {
            var db = new LibraryDbContext();
            Book item = db.Books.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }

        }

        protected void InsertBook_Click(object sender, EventArgs e)
        {
            this.BooksListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void BooksListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.BooksListView.InsertItemPosition = InsertItemPosition.None;
            ErrorSuccessNotifier.AddSuccessMessage("Book created successfully!");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.BooksListView.InsertItemPosition = InsertItemPosition.None;
        }

        public IEnumerable<Category> Categories_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories.OrderBy(b => b.Name).ToList();
        }
    }
}