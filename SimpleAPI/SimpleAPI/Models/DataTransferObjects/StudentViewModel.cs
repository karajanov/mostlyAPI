using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models.DataTransferObjects
{
    public class StudentViewModel
    {

        [StringLength(50)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string StudentEmail { get; set; }

        [StringLength(8)]
        public string StudentId { get; set; }

        [StringLength(500)]
        public string StudentDescription { get; set; }

        public DateTime? StudentEnrolledDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? IsRegular { get; set; }

    }
}
