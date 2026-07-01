using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System_ERD___Models.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int orderId { get; set; }//system generated


        

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime orderDate { get; set; }//default

        [Required]
        [Range(0,double.MaxValue)]
        public decimal totalAmount { get; set; }//calculated

        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";//default 

        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; }//user input

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }//user input

        [ForeignKey("User")]
        public int? userId { get; set; } //fk (to user)
        public User User { get; set; }//navigation property

        public ICollection<Product>products { get; set; }//navigation property
    }
}
