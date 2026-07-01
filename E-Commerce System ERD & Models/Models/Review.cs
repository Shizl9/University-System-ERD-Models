using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System_ERD___Models.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int reviewId { get; set; }//system generated 

        
        

        [Range(1,5)]
        public int rating { get; set; }//usser input 

        [MaxLength(1000)]
        public string? comment { get; set; }//user input

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime reviewDate { get; set; }//default

        [ForeignKey("Product")]
        public int? productId { get; set; }//fk (to product)
        public Product Product { get; set; }//navigation proberty


        [ForeignKey("User")]
        public int? userId { get; set; }//fk (to user)
        public User User { get; set; } //navigation property

    }
}
