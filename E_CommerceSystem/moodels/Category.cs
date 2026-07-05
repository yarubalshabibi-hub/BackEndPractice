using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace E_CommerceSystem.moodels
{
    [Index(nameof(categoryName), IsUnique = true]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; }                    // system generated — auto PK

        [Required]
        [MaxLength(100)]
        public string categoryName { get; set; }               // user input — must be unique

        [MaxLength(500)]
        public string description { get; set; }                // user input — optional

        [MaxLength(300)]
        public string imageUrl { get; set; }                   // user input — optional

        // ── Navigation Property ───────────────────────────────
        // One Category groups MANY Products (1:M)
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
