using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static WeddingPlannerDemo.CustomerValidators;

namespace WeddingPlannerDemo.Models
{
    public class Wedding
    {
        [Key] // Primary Key
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }

        [FutureDate]
        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Wedding Address")]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/
        public int UserId { get; set; } // Foreign Key - 1 User : Many Weddings
        public User CreatedBy { get; set; } // 1 User : Many Wedding
        public List<UserWeddingRSVP> RSVPs { get; set; } // Many User : Many Wedding

    }
}