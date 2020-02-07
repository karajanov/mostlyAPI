using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
    public partial class Activities
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("studentId")]
        public int? StudentId { get; set; }
        [Column("courseId")]
        public int? CourseId { get; set; }
        [Column("datePresented", TypeName = "datetime")]
        public DateTime? DatePresented { get; set; }
        [Column("activityType")]
        public int? ActivityType { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Activities")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentData.Activities))]
        public virtual StudentData Student { get; set; }
    }
}
