using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityManagmentSystem.Moodels;

namespace UniversitySystem.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.identity)]
        public int courseId { get; set; } // system generated

        [Required]
        [MaxLength(10)]
        public string courseCode { get; set; } // user input (must be unique, e.g. CS101)

        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; } // user input

        [Required]
        [Range(1, 6)]
        public int creditHours { get; set; } // user input

        // Foreign key: department this course belongs to (required)
        [Required]
        [ForeignKey(nameof(department))]
        public int departmentId { get; set; } // foreign key

        // Navigation property: the department this course belongs to (the "many" side)
        public Department department { get; set; } // navigation property

        // Foreign key: instructor teaching this course (nullable - may be unassigned)
        [ForeignKey(nameof(instructor))]
        public int? instructorId { get; set; } // foreign key

        // Navigation property: the instructor teaching this course (the "many" side)
        public Instructor? instructor { get; set; } // navigation property

        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; } // user input, from list (e.g. Fall 2026)

        // Navigation property: one course has many enrollments
        public List<Enrollment> enrollments { get; set; } = new List<Enrollment>(); // navigation property
    }
}
