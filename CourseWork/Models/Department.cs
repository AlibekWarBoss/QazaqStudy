using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class Department
    {
        [Required]
        [Display(Name = "Id ERROR")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name ERROR")]
        public string Department_Name { get; set; }

        ICollection<Course> Courses{ get; set; }

        public Department()
        {
            Courses = new List<Course>();
        }

        public Department(int id, string department_Name, ICollection<Course> courses)
        {
            Id = id;
            Department_Name = department_Name;
            Courses = courses;
        }
    }
}