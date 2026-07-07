using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.moodels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }                       // system generated — auto PK

        // ── Foreign Key: User ─────────────────────────────────
        [Required]
        public int userId { get; set; }                        // from list — not null (total participation)

        [ForeignKey("UserId")]
        public User user { get; set; }                         // navigation — single object (many side)

        [Required]
        public DateTime orderDate { get; set; }                // system generated — set to today automatically

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal totalAmount { get; set; }               // calculated — sum of all OrderItems prices

        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";        // default value — "Pending" when first created

        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; }            // user input

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }              // user input

        // ── Navigation Property ───────────────────────────────
        // One Order contains MANY OrderItems (M:N bridge — NEVER direct collection to Product)
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
