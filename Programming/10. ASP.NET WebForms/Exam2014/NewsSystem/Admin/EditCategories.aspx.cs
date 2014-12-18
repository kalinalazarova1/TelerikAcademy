using Error_Handler_Control;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        private NewsDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new NewsDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> CategoriesListView_GetData()
        {
            return db.Categories.OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesListView_DeleteItem(int Id)
        {
            var selected = db.Categories.Find(Id);
            db.Categories.Remove(selected);
            db.SaveChanges();
        }

        public void CategoriesListView_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);

            if(string.IsNullOrWhiteSpace(item.Name))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category Name could not be empty");
            }
            else if (db.Categories.Any(c => c.Name == item.Name))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category Name already exists.");
            } 
            else
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(item);
                    db.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Category successfully created.");
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void CategoriesListView_UpdateItem(int Id)
        {
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
                ErrorSuccessNotifier.AddSuccessMessage("Category successfully updated.");
            }
        }
    }
}