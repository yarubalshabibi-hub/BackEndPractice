using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace E_CommerceSystem.moodels
{
    [Index(nameof(email), IsUnique = true]

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }                        // system generated — auto PK

        [Required]
        [MaxLength(50)]
        public string username { get; set; }                   // user input — must be unique

        [Required]
        [MaxLength(150)]
        public string email { get; set; }                      // user input — must be unique

        [Required]
        [MaxLength(256)]
        public string passwordHash { get; set; }               // system generated — hashed, never plain text

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }                   // user input

        [MaxLength(20)]
        public string phoneNumber { get; set; }                // user input — optional

        [MaxLength(300)]
        public string address { get; set; }                    // user input — optional

        [Required]
        public DateTime registrationDate { get; set; }         // system generated — set to today automatically

        public bool isActive { get; set; } = true;             // default value — true when first registered

        // Navigation Properties 
        // One User places MANY Orders (1:M)
        public List<Order> Orders { get; set; } = new List<Order>();

        // One User writes MANY Reviews (1:M)
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
