using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class LikeControl : System.Web.UI.UserControl
    {
        private NewsDbContext db;

        public string ReaderId 
        {
            get
            {
                return this.ReaderId;
            }
            set
            {
                this.ReaderId = value;
            }
        }

        public string ArticleId
        {
            get
            {
                return this.ArticleId;
            }
            set
            {
                this.ArticleId = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.ReaderId == string.Empty)
            {
                this.content.Visible = false;
                this.LikesLiteral.Text = db.Articles.Find(int.Parse(this.ArticleId)).Likes.Sum(l => l.Value).ToString();
            }

            this.db = new NewsDbContext();
        }

        protected void Up_Click(object sender, EventArgs e)
        {
            var like = new Like() 
            {
                ArticleId = int.Parse(this.ArticleId),
                ReaderId = this.ReaderId,
                Value = 1
            };

            var current = db.Articles.Find(this.ArticleId);
            if (current.Likes.All(l => l.ReaderId != this.ReaderId))
            {
                current.Likes.Add(new Like());
                db.SaveChanges();
            }
        }

        protected void Down_Click(object sender, EventArgs e)
        {
            var like = new Like()
            {
                ArticleId = int.Parse(this.ArticleId),
                ReaderId = this.ReaderId,
                Value = -1
            };

            var current = db.Articles.Find(this.ArticleId);
            if(current.Likes.All(l => l.ReaderId != this.ReaderId))
            {
                current.Likes.Add(new Like());
                db.SaveChanges();
            }
        }
    }
}