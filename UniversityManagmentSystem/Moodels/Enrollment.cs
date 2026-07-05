using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagmentSystem.Moodels
{
    public class Enrollment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enrollmentId { get; set; }                   // system generated — auto-incremented 

        // Foreign Key: Student 
        [Required]
        public int studentId { get; set; }                       // from list — not null

        [ForeignKey("StudentId")]
        public Student student { get; set; }                     // navigation — single object (the "1" side)

        // Foreign Key: Course
        [Required]
        [ForeignKey("Course")]
        public int courseId { get; set; }                        // from list — not null

        public course Course { get; set; }                       // navigation — single object (the "1" side)

        [Required]
        public DateTime enrollmentDate { get; set; }              // system generated — set to today when enrolling

        [MaxLength(2)]
        public string finalGrade { get; set; }                    // calculated — set later when graded, null until then

        [Required]
        [MaxLength(20)]
        public string status { get; set; } = "In Progress";       // default value — "In Progress" when first created
    }
}
