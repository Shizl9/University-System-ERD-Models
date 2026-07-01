using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_System_ERD___Models.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int departmentId { get; set; }//system generated

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; } // user input


        [MaxLength(50)]    //? ==> for obtional and not null preberties
        public string? building { get; set; } //user input


        [Required]
        [Range(0, double.MaxValue)]
        public decimal budget { get; set; }  //user input



        //(1 dept - 1 instructor):

        // FK
        public int? headInstructorId { get; set; } //foreign key proberty

        //came from instructor class==> foreign key
        [ForeignKey("headInstructor")]

        public Instructor headInstructor { get; set; } //navigation proberty

        //(1 dept - M courcess):
        public ICollection<Course>courses { get; set; }//navigation
    }
}
