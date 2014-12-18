using _02.SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SimpleChat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public void lvMessages_InsertItem()
        {
            var db = new SimpleChatDbContext();
            var item = new Message();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                item.TimeStamp = DateTime.Now;
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
            var db = new SimpleChatDbContext();
            return db.Messages
                .AsQueryable()
                .OrderByDescending(m => m.TimeStamp)
                .Take(100)
                .OrderBy(m => m.TimeStamp);
        }

        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            lvMessages.DataBind();
        }

        protected void SaveMessage_Click(object sender, EventArgs e)
        {
            var db = new SimpleChatDbContext();
            var item = new Message();
            item.TimeStamp = DateTime.Now;
            item.Author = this.Author.Text;
            item.Content = this.Content.Text;
            db.Messages.Add(item);
            db.SaveChanges();
            this.Author.Text = string.Empty;
            this.Content.Text = string.Empty;
            lvMessages.DataBind();
        }
    }
}