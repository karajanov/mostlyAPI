using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
    public partial class StudentData
    {
        public StudentData()
        {
            Activities = new HashSet<Activities>();
            EnrolledIn = new HashSet<EnrolledIn>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string StudentName { get; set; }
        [StringLength(50)]
        public string StudentEmail { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StudentEnrolledDate { get; set; }
        [StringLength(8)]
        public string StudentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(500)]
        public string StudentDescription { get; set; }
        [Column("isRegular")]
        public bool? IsRegular { get; set; }

        [InverseProperty("Student")]
        public virtual ICollection<Activities> Activities { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<EnrolledIn> EnrolledIn { get; set; }
    }
}
