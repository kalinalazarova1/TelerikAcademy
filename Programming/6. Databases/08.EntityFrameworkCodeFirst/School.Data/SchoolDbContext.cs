namespace School.Data
{
    using School.Data.Migrations;
    using School.Models;
    using System.Data.Entity;

    public class SchoolDbContext : DbContext, ISchoolDbContext
    {
        public SchoolDbContext()
            : base ("School")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
