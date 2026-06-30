using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_System_ERD___Models.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? enrollmentId { get; set; } // system generated


        [Required]
        public int studentId { get; set; } // foreign key

        [Required]
        public int courseId { get; set; } // foreign key


        [Required]
        public DateTime enrollmentDate { get; set; } // user input


        [MaxLength(2)]
        public string? finalGrade { get; set; } // optional

        [Required]
        [MaxLength(20)]
        public string status { get; set; } = "In Progress"; // default value
    }
}
