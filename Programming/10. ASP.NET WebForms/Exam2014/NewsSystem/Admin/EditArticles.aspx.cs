using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;

namespace NewsSystem.Admin
{
    public partial class EditArticles : System.Web.UI.Page
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
        public IQueryable<Article> ArticlesListView_GetData()
        {
           return db.Articles.OrderBy(b => b.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ArticlesListView_DeleteItem(int Id)
        {
            var selected = db.Articles.Find(Id);
            db.Articles.Remove(selected);
            db.SaveChanges();
        }

        public void ArticlesListView_InsertItem()
        {
            var item = new Article();
            item.DateCreated = DateTime.Now;
            item.AuthorId = this.User.Identity.GetUserId();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.Articles.Add(item);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ArticlesListView_UpdateItem(int Id)
        {
            Article item = db.Articles.Find(Id);
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
                ErrorSuccessNotifier.AddSuccessMessage("Article successfully updated.");
            }

        }

        protected void InsertArticle_Click(object sender, EventArgs e)
        {
            this.ArticlesListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ArticlesListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ArticlesListView.InsertItemPosition = InsertItemPosition.None;
            ErrorSuccessNotifier.AddSuccessMessage("Article successfully created.");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.ArticlesListView.InsertItemPosition = InsertItemPosition.None;
        }

        public IEnumerable<Category> Categories_GetData()
        {
            var localDb = new NewsDbContext();
            return localDb.Categories.OrderBy(b => b.Name).ToList();
        }
    }
}