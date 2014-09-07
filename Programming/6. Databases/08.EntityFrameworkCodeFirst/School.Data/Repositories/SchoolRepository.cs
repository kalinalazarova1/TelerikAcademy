namespace School.Data
{
    using School.Data.Repositories;
    using School.Models;
    using System;
    using System.Collections.Generic;

    public class SchoolRepository : ISchoolRepository
    {
        private ISchoolDbContext context;
        private IDictionary<Type, object> repositories;

        public SchoolRepository()
            : this(new SchoolDbContext())
        {
        }

        public SchoolRepository(ISchoolDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IGenericRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IGenericRepository<Resource> Resources
        {
            get
            {
                return this.GetRepository<Resource>();
            }
        }

        public IGenericRepository<Homework> Homeworks
        {
            get
            {
                return this.GetRepository<Homework>();
            }
        }

        public IGenericRepository<Student> Students
        {
            get
            {
                return this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
