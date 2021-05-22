using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class Course
    {
        public int Id { get; set; }    
        [Required]
        [Display(Name = "Course Name ERROR")]
        public string Course_Name { get; set; }


        public int? LevelId { get; set; }  
        public CourseLevel Level { get; set; } 


        public int? DepartmentId { get; set; }   
        public Department Department { get; set; }   

        [Required]
        [Display(Name = "Course Duration ERROR")]
        public int CourseDuration { get; set; }
      
        ICollection<Payment> Payments { get; set; }

        public Course()
        {
            Payments = new List<Payment>();
        }

        public Course(int id, string course_Name, int? levelId, CourseLevel level, int? departmentId, Department department, int courseDuration, ICollection<Payment> payments)
        {
            Id = id;
            Course_Name = course_Name;
            LevelId = levelId;
            Level = level;
            DepartmentId = departmentId;
            Department = department;
            CourseDuration = courseDuration;
            Payments = payments;
        }
    }
}