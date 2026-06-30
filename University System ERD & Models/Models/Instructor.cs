using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_System_ERD___Models.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int instructorId { get; set; } //system generated
        
        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } //user input


        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        [MaxLength(150)]
        public string email { get; set; } //user input

        [MaxLength(20)]    //? ==> for obtional and not null preberties
        public string? officeNumber { get; set; } //user input


        [Required]
        public string hireDate { get; set; } //user input

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal salary { get; set; }  //user input

        [Required]
        [MaxLength(50)]
        public string academicTitle { get; set; } //user input

        public Department departmentHead { get; set; }//navigation 

        public ICollection<Course> courses { get; set; }////navigation

    }
}
