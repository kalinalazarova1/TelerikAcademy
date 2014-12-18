using _02.SimpleChat.Migrations;
using _02.SimpleChat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02.SimpleChat
{
    public class SimpleChatDbContext: DbContext
    {
        public SimpleChatDbContext ()
            : base("SimpleChat")
	    {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleChatDbContext, Configuration>());    
	    }

        public IDbSet<Message> Messages { get; set; }
    }
}