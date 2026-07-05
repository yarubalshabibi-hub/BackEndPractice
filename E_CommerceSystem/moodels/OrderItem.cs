using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.moodels
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }                   // system generated — auto PK

        // ── Foreign Key: Order ────────────────────────────────
        [Required]
        public int orderId { get; set; }                       // foreign key — links to Order (total)

        [ForeignKey("OrderId")]
        public Order order { get; set; }                       // navigation — single object (many side)

        // ── Foreign Key: Product ──────────────────────────────
        [Required]
        public int productId { get; set; }                     // foreign key — links to Product

        [ForeignKey("ProductId")]
        public Product product { get; set; }                   // navigation — single object (many side)

        // ── Relationship Attribute ────────────────────────────
        [Required]
        [Range(1, 999)]
        public int quantity { get; set; }                      // user input — how many of this product in the order

    }
}
