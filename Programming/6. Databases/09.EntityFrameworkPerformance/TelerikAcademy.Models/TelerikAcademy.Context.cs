﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikAcademy.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TelerikAcademyEntities : DbContext
    {
        public TelerikAcademyEntities()
            : base("name=TelerikAcademyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
    
        [DbFunction("TelerikAcademyEntities", "udf_FindNamesWithPattern")]
        public virtual IQueryable<udf_FindNamesWithPattern_Result> udf_FindNamesWithPattern(string pattern)
        {
            var patternParameter = pattern != null ?
                new ObjectParameter("pattern", pattern) :
                new ObjectParameter("pattern", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udf_FindNamesWithPattern_Result>("[TelerikAcademyEntities].[udf_FindNamesWithPattern](@pattern)", patternParameter);
        }
    }
}
