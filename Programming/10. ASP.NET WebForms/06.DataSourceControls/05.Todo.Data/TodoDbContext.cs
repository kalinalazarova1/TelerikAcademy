using _05.Todo.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Todo.Models;

namespace _05.Todo.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
            : base("TodosDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodoDbContext, Configuration>());
        }

        public IDbSet<TodoTask> Todos { get; set; }

        public IDbSet<Category> Categories { get; set; }

    }
}
