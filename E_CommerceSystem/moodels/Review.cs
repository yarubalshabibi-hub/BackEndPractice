using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.moodels
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; }                      // system generated — auto PK


        // ── Foreign Key: User ─────────────────────────────────
        [Required]
        [ForeignKey("user")]
        public int userId { get; set; }                        // from list — not null (total participation)


        
        public User user { get; set; }                         // navigation — single object (many side)


        // ── Foreign Key: Product ──────────────────────────────
        [Required]
        [ForeignKey("product")]
        public int productId { get; set; }                     // from list — not null (total participation)


        
        public Product product { get; set; }                   // navigation — single object (many side)


        [Required]
        [Range(1, 5)]
        public int rating { get; set; }                        // user input — 1 to 5 stars


        [MaxLength(1000)]
        public string? comment { get; set; }                    // user input — optional


        [Required]
        public DateTime reviewDate { get; set; }               // system generated — set to today automatically


    }
}
