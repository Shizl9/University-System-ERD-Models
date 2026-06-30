using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_System_ERD___Models.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int studentId { get; set; }//system generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } //user input


        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        [MaxLength(150)]
        public string email { get; set; } //user input



        [MaxLength(20)]    //? ==> for obtional and not null preberties
        public string ?phoneNumber { get; set; } //user input

        [Required]
        public string dateOfBirth { get; set; } //user input

        [Required]
        [Range(2000,2030)]
        public int enrollmentYear { get; set; } //user input

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//for default value that generated from system
        [Range(0.0,4.0)]
        public decimal gpa { get; set; } //default 

        public ICollection<Enrollment> enrollments { get; set; } //navigation
    }
}
