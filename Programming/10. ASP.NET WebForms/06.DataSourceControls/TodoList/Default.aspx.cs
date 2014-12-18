using _03.Todo.Models;
using _05.Todo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void lvCategories_DeleteItem(int id)
        {
            var db = new TodoDbContext();
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            this.lvCategories.DataBind();
        }

        public void lvCategories_InsertItem()
        {
            var db = new TodoDbContext();
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var itemData = new Category()
                {
                    Name = item.Name
                };
                db.Categories.Add(itemData);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void lvCategories_UpdateItem(int Id)
        {
            var db = new TodoDbContext();
            Category item = null;
            var itemData = db.Categories.Find(Id);

            if (itemData == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }

            item = new Category()
            {
                Name = itemData.Name
            };
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                itemData.Name = item.Name;
                db.SaveChanges();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable lvCategories_GetData()
        {
            var db = new TodoDbContext();
            return db.Categories.AsQueryable();
        }

        protected void InsertCategoryFormBtn_Click(object sender, EventArgs e)
        {
            this.lvCategories.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewTowns_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.lvCategories.InsertItemPosition = InsertItemPosition.None;
            this.lvCategories.DataBind();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            this.lvCategories.InsertItemPosition = InsertItemPosition.None;
            Response.Redirect("~/Default.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewTodos_DeleteItem(int id)
        {
            var db = new TodoDbContext();
            var todos = db.Todos.Find(id);
            db.Todos.Remove(todos);
            db.SaveChanges();
            this.ListViewTodos.DataBind();
        }

        public void ListViewTodos_InsertItem()
        {
            var db = new TodoDbContext();
            var item = new TodoTask();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                var itemData = new TodoTask()
                {
                    Title = item.Title,
                    Body = item.Body,
                    LastModified = DateTime.Now,
                    CategoryId = item.CategoryId
                };
                db.Todos.Add(itemData);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewTodos_UpdateItem(int Id)
        {
            var db = new TodoDbContext();
            TodoTask item = null;
            var itemData = db.Todos.Find(Id);

            if (itemData == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }

            item = new TodoTask()
            {
                Title = itemData.Title,
                Body = itemData.Body,
                LastModified = DateTime.Now,
                CategoryId = itemData.CategoryId
            };
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                itemData.Title = item.Title;
                itemData.Body = item.Body;
                itemData.LastModified = item.LastModified;
                itemData.CategoryId = item.CategoryId;
                db.SaveChanges();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TodoTask> ListViewTodos_GetData()
        {
            var db = new TodoDbContext();
            return db.Todos.AsQueryable();
        }

        protected void InsertTodoFormBtn_Click(object sender, EventArgs e)
        {
            this.ListViewTodos.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void CancelButton1_Click(object sender, EventArgs e)
        {
            this.ListViewTodos.InsertItemPosition = InsertItemPosition.None;
            Response.Redirect("~/Default.aspx");
        }
    }
}