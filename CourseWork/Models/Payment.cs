using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class Payment
    {
        [Required]
        [Display(Name = "Id ERROR")]
        public int Id { get; set; }    // PK

        public int? StudentId { get; set; } //FK 
        public Student Student { get; set; } //FK 


        public int? CourseId { get; set; }   //FK
        public Course Course{ get; set; }   //FK

        public int? PriceId { get; set; }   //FK
        public Price Price{ get; set; }   //FK

        public DateTime dateOfPay { get; set; }

        ICollection<CourseSelection> CourseSelections{ get; set; }

        public Payment()
        {
            CourseSelections = new List<CourseSelection>();
        }

        public Payment(int id, int? studentId, Student student, int? courseId, Course course, int? priceId, Price price, DateTime dateOfPay, ICollection<CourseSelection> courseSelections)
        {
            Id = id;
            StudentId = studentId;
            Student = student;
            CourseId = courseId;
            Course = course;
            PriceId = priceId;
            Price = price;
            this.dateOfPay = dateOfPay;
            CourseSelections = courseSelections;
        }
    }
}