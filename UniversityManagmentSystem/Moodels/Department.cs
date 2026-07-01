using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagmentSystem.Moodels
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.identity)]
        public int departmentId { get; set; }                  // system generated — auto-incremented PK

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; }              // user input — must be unique

        [MaxLength(50)]
        public string building { get; set; }                    // user input — optional

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Range(0, double.MaxValue)]
        public decimal budget { get; set; }                     // user input — must be >= 0

        //Foreign Key 
        public int? headInstructorId { get; set; }              // from list — nullable (may have no head yet)

        [ForeignKey("HeadInstructorId")]
        public Instructor headInstructor { get; set; }          // navigation — single object (the "1" side)

        // Navigation Property 
        // One Department offers MANY Courses (1 : M)
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
