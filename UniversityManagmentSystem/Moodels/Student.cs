using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagmentSystem.Moodels
{
    [Index(nameof(email), IsUnique = true]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.identity)]
        public int studentId { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // user input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // user input (must be unique - enforce via index/config)

        [MaxLength(20)]
        public string? phoneNumber { get; set; } // user input (optional)

        [Required]
        public DateTime dateOfBirth { get; set; } // user input

        [Required]
        [Range(2000, 2030)]
        public int enrollmentYear { get; set; } // user input

        [Column(typeName = "decimal(3,2)")]
        [Range(0.0, 4.0)]
        public decimal gpa { get; set; } = 0.0m; // default value (recalculated/calculated over time)

        // Navigation property: one student has many enrollments
        public List<Enrollment> Enrollments { get; set; }  // navigation property

    }
}
