using _01.LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LibrarySystem.Categories
{
    public partial class Categories : System.Web.UI.Page
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
        public IQueryable<Category> CategoriesListView_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories.OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesListView_DeleteItem(int Id)
        {
            var db = new LibraryDbContext();
            var selected = db.Categories.Find(Id);
            db.Categories.Remove(selected);
            db.SaveChanges();
        }

        public void CategoriesListView_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();
                db.Categories.Add(item);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesListView_UpdateItem(int Id)
        {
            var db = new LibraryDbContext();
            Category item = db.Categories.Find(Id);
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

        protected void InsertCategory_Click(object sender, EventArgs e)
        {
            this.CategoriesListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CategoriesListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.CategoriesListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.CategoriesListView.InsertItemPosition = InsertItemPosition.None;
        }

        protected void CategoriesListView_Sorted(object sender, EventArgs e)
        {

        }
    }
}