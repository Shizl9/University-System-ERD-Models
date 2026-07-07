using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System_ERD___Models.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int orderitemId { get; set; }
        [Required]
        [Range(1,999)]
       
        public int quantity { get; set; }//input


        // foreign key — every order item belongs to exactly one order
        [Required]
        [ForeignKey("Order")]
        public int orderId { get; set; }                  // system generated — from the active order
        public Order Order { get; set; }

        // foreign key — every order item references exactly one product
        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }                // from list — chosen from available products
        public Product Product { get; set; }              // navigation property
        public decimal unitPrice { get;  set; }
    }
}
