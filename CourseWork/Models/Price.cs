using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class Price
    {
        [Required]
        [Display(Name = "Id ERROR")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "price ERROR")]
        public int price { get; set; }

        ICollection<Payment> Payments { get; set; }

        public Price()
        {
            Payments = new List<Payment>();
        }

        public Price(int id, int price, ICollection<Payment> payments)
        {
            Id = id;
            this.price = price;
            Payments = payments;
        }
    }
}