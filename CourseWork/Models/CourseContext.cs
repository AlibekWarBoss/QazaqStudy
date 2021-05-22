using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CourseWork.Models
{
    public class CourseContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        
        public DbSet<CourseSelection> CourseSelections{ get; set; }

        public System.Data.Entity.DbSet<CourseWork.Models.Price> Prices { get; set; }

        public CourseContext(DbSet<Department> departments, DbSet<CourseLevel> courseLevels, DbSet<Course> courses, DbSet<Student> students, DbSet<Payment> payments, DbSet<CourseSelection> courseSelections, DbSet<Price> prices)
        {
            Departments = departments;
            CourseLevels = courseLevels;
            Courses = courses;
            Students = students;
            Payments = payments;
            CourseSelections = courseSelections;
            Prices = prices;
        }
    }


}