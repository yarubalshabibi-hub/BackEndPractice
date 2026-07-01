using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagmentSystem.Moodels
{
    internal class Enrollment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }                   // system generated — auto-incremented PK

        // ── Foreign Key: Student 
        [Required]
        public int StudentId { get; set; }                       // from list — not null

        [ForeignKey("StudentId")]
        public Student Student { get; set; }                     // navigation — single object (the "1" side)

        // ── Foreign Key: Course
        [Required]
        public int CourseId { get; set; }                        // from list — not null

        [ForeignKey("CourseId")]
        public Course Course { get; set; }                       // navigation — single object (the "1" side)

        [Required]
        public DateTime EnrollmentDate { get; set; }              // system generated — set to today when enrolling

        [MaxLength(2)]
        public string FinalGrade { get; set; }                    // calculated — set later when graded, null until then

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "In Progress";       // default value — "In Progress" when first created
    }
}
