using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
    public partial class EnrolledIn
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("studentId")]
        public int? StudentId { get; set; }
        [Column("courseId")]
        public int? CourseId { get; set; }
        [Column("studentYear")]
        [StringLength(4)]
        public string StudentYear { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("EnrolledIn")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentData.EnrolledIn))]
        public virtual StudentData Student { get; set; }
    }
}
