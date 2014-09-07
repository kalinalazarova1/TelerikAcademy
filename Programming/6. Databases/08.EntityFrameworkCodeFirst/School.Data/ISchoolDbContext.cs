namespace School.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using School.Models;

    public interface ISchoolDbContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Resource> Resources { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
