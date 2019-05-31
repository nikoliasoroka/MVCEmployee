using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC.Data.Models
{
    public class Context : DbContext
    {
        public Context() : base("Context")
        {

        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("TeacherCourses").MapLeftKey("CourseId").MapRightKey("TeacherId"));
        }
    }
}