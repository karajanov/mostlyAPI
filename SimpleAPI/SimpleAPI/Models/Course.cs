using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Activities = new HashSet<Activities>();
            EnrolledIn = new HashSet<EnrolledIn>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("courseName")]
        [StringLength(50)]
        public string CourseName { get; set; }
        [Column("professor")]
        [StringLength(50)]
        public string Professor { get; set; }
        [Column("semesterYear")]
        [StringLength(4)]
        public string SemesterYear { get; set; }
        [StringLength(500)]
        public string StudentDescription { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Activities> Activities { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<EnrolledIn> EnrolledIn { get; set; }
    }
}
