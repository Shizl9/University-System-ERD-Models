using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System_ERD___Models.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int productId { get; set; }// systm geneated

        [Required]
        [MaxLength(150)]
        public string productName { get; set; } //user input

        [MaxLength(1000)]
        public string ?description { get; set; }//user input

        [Required]
        [Range(0, double.MaxValue)]
        public decimal price { get; set; }  //user input

        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0; //default

        [MaxLength(300)]
        public string ?imageUrl { get; set; } //user input

        

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime createdAt { get; set; }//default


        public bool isAvailable { get; set; } = true;//default


        //==================================================

        public ICollection<Order> orders { get; set; }//navigation property

        [ForeignKey("Category")]
        public int? categoryId { get; set; }//fk (to category)
        public virtual Category Category { get; set; }//navigation property

        public virtual ICollection<Review> reviews { get; set; }//navigation property
    }
}
