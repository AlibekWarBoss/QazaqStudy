using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class CourseLevel
    {
        [Required]
        [Display(Name = "Id ERROR")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Level Name ERROR")]
        public string Level_Name { get; set; }

        ICollection<Course> Courses { get; set; }

        public CourseLevel()
        {
            Courses = new List<Course>();
        }

        public CourseLevel(int id, string level_Name, ICollection<Course> courses)
        {
            Id = id;
            Level_Name = level_Name;
            Courses = courses;
        }
    }
}