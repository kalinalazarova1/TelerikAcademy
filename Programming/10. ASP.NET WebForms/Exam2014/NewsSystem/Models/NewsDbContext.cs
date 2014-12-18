using Microsoft.AspNet.Identity.EntityFramework;
using NewsSystem.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewsSystem.Models
{
    public class NewsDbContext : IdentityDbContext<AppUser>
    {
        public NewsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public static NewsDbContext Create()
        {
            return new NewsDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Like> Likes { get; set; }

    }
}