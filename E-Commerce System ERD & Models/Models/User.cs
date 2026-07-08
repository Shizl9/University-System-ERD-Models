using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_System_ERD___Models.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int userId { get; set; } //system generated

        [Required]
        [MaxLength(50)]
        public string username { get; set; } //user input

        [Required]
        [MaxLength(150)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string email { get; set; } // user input

        [Required]
        [MaxLength(256)]
        [RegularExpression(@"^.{1,256}$")]
        public string passwordHash { get; set; } //user input

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }//user input

        [MaxLength(20)]
        public string? phoneNumber { get; set; }//user input

        [MaxLength(300)]
        public string ?address { get; set; } //User input

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime registrationDate { get; set; }//default //system generate it

        public bool isActive { get; set; } = true; //default



        //=====================================================
        public ICollection<Order> orders { get; set; }//navigation proberty

        public ICollection<Review>reviews { get; set; }//navigation proberty
    }
}
