using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagmentSystem.Moodels
{
    [Index(nameof(email),IsUnique = true]
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instructorId { get; set; } // system generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // user input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // user input (must be unique - enforce via index/config)

        [MaxLength(20)]
        public string? officeNumber { get; set; } // user input (optional)

        [Required]
        public DateTime hireDate { get; set; } // user input

        [Required]
        [Range(typeof(decimal), "0.01", "9999999")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal salary { get; set; } // user input (must be > 0)

        [Required]
        [MaxLength(50)]
        public string academicTitle { get; set; } // user input, from list (e.g. Professor, Lecturer)

        // Navigation property: one instructor teaches many courses
        public List<Course> Courses { get; set; } = new List<Course>(); // navigation property

        // Navigation property: one instructor may be the head of at most one department
        public Department? headOfDepartment { get; set; } // navigation property (inverse of Department.HeadInstructor)
    }
}
