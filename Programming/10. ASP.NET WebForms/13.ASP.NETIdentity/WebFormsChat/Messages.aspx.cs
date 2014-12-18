using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsChat.Models;
using Microsoft.AspNet.Identity;

namespace WebFormsChat
{
    public partial class Contact : Page
    {
        private ChatDbContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.db = new ChatDbContext();
        }

        public void lvMessages_InsertItem()
        {
            var db = new ChatDbContext();
            var item = new Message();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                item.CreationDate = DateTime.Now;
                db.Messages.Add(item);
                db.SaveChanges();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Message> lvMessages_GetData()
        {
            var db = new ChatDbContext();
            return db.Messages
                .AsQueryable()
                .OrderByDescending(m => m.CreationDate)
                .Take(10)
                .OrderBy(m => m.CreationDate);
        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            lvMessages.DataBind();
        }

        protected void SaveMessage_Click(object sender, EventArgs e)
        {
            var db = new ChatDbContext();
            var item = new Message();
            item.CreationDate = DateTime.Now;
            item.UserId = this.User.Identity.GetUserId();
            item.Content = this.Content.Text;
            db.Messages.Add(item);
            db.SaveChanges();
            this.Content.Text = string.Empty;
            lvMessages.DataBind();
        }

    }
}