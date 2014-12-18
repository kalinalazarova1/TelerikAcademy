using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebFormsChat.Migrations;

namespace WebFormsChat.Models
{
    public class ChatDbContext : IdentityDbContext<User>
    {
        public ChatDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
        }

        public static ChatDbContext Create()
        {
            return new ChatDbContext();
        }

        public IDbSet<Message> Messages { get; set; }
    }
}