using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class Student
    {
        [Required]
        [Display(Name = "Id ERROR")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name ERROR")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname ERROR")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Age ERROR")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Country ERROR")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Email ERROR")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Login ERROR")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Password ERROR")]
        public string Password { get; set; }

        ICollection<Payment> Payments { get; set; }

        public Student()
        {
            Payments = new List<Payment>();
        }

        public Student(int id, string name, string surname, int age, string country, string email, string login, string password, ICollection<Payment> payments)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Country = country;
            Email = email;
            Login = login;
            Password = password;
            Payments = payments;
        }
    }
}