using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsChat.Models;
using Microsoft.AspNet.Identity;

namespace WebFormsChat.Admin
{
    public partial class EditDeleteMessages : System.Web.UI.Page
    {
        private ChatDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ChatDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Message> MessagesListView_GetData()
        {
            var db = new ChatDbContext();

            return db.Messages.OrderByDescending(b => b.CreationDate);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MessagesListView_DeleteItem(int Id)
        {
            var db = new ChatDbContext();
            var selected = db.Messages.Find(Id);
            db.Messages.Remove(selected);
            db.SaveChanges();
        }

        public void MessagesListView_InsertItem()
        {
            var item = new Message();
            TryUpdateModel(item);
            item.CreationDate = DateTime.Now;
            item.UserId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                var db = new ChatDbContext();
                db.Messages.Add(item);
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MessagesListView_UpdateItem(int Id)
        {
            var db = new ChatDbContext();
            Message item = db.Messages.Find(Id);
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

        protected void InsertMessage_Click(object sender, EventArgs e)
        {
            this.MessagesListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void MessagesListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.MessagesListView.InsertItemPosition = InsertItemPosition.None;
            ErrorSuccessNotifier.AddSuccessMessage("Message created successfully!");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.MessagesListView.InsertItemPosition = InsertItemPosition.None;
        }
    }
}