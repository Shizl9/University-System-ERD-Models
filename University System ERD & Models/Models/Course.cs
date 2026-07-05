using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_System_ERD___Models.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int courseId { get; set; }//system generated


        [Required]
        [MaxLength(10)]
        public string courseCode { get; set; } // user input


        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; } //user input


        [Required]
        [Range(1,6)]
        public int creditHours { get; set; } //user input

        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; } //user input

        //(1 dept - M courcess):

        // FK
        [Required]
        //fk+navigation
        [ForeignKey("department")]
        public int ?departmentId { get; set; } //(not null)

       
        public Department department { get; set; }//navigation

        //(1 instructor - M courcess):

        //fk
        [Required]
        [ForeignKey("Instructor")]

        public int? instructorId { get; set; } // foreign key (not null)
       
        //fk+navigation:
        public Instructor Instructor { get; set; } //navigation


        public ICollection<Enrollment> enrollments { get; set; } //navigation

    }
}
