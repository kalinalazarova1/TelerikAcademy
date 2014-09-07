namespace School.Data
{
    using School.Data.Repositories;
    using School.Models;

    public interface ISchoolRepository
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Student> Students { get; }

        IGenericRepository<Resource> Resources { get; }
    }
}
