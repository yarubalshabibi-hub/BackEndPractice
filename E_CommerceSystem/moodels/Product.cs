using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.moodels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }                     // system generated — auto PK

        [Required]
        [MaxLength(150)]
        public string productName { get; set; }                // user input

        [MaxLength(1000)]
        public string description { get; set; }               // user input — optional

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.maxValue)]
        public decimal price { get; set; }                     // user input — must be > 0

        [Required]
        [Range(0, int.maxValue)]
        public int stockQuantity { get; set; } = 0;            // default value — starts at 0

        [MaxLength(300)]
        public string imageUrl { get; set; }                   // user input — optional

        // ── Foreign Key: Category ─────────────────────────────
        [Required]
        public int categoryId { get; set; }                    // from list — not null (total participation)

        [ForeignKey("CategoryId")]
        public Category category { get; set; }                 // navigation — single object (many side)

        [Required]
        public DateTime createdAt { get; set; }                // system generated — set when product is added

        public bool isAvailable { get; set; } = true;          // default value — available when first added

        // ── Navigation Properties ─────────────────────────────
        // One Product appears in MANY OrderItems (M:N bridge)
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // One Product has MANY Reviews (1:M)
        public List<Review> Reviews { get; set; } = new List<Review>();
     
    }
}
