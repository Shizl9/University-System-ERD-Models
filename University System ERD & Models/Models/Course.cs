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


        // FK
        [Required]
        public int ?departmentId { get; set; } //(not null)

        //fk
        [Required]
        public int? instructorId { get; set; } // foreign key (not null)


        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; } //user input
        
        //fk+navigation
        [ForeignKey("departmentId")]
        public Department department { get; set; }//navigation

        //fk+navigation:
        [ForeignKey("instructorId")]
        public Instructor Instructor { get; set; } //navigation
        public ICollection<Enrollment> enrollments { get; set; } //navigation

    }
}
