using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models.DataTransferObjects
{
    public class CourseViewModel
    {
        
        [StringLength(50)]
        public string CourseName { get; set; }

        [StringLength(50)]
        public string Professor { get; set; }

        [StringLength(4)]
        public string SemesterYear { get; set; }

        [StringLength(500)]
        public string StudentDescription { get; set; }

    }
}
