using SimpleAPI.Models.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models.QueryModels
{
    public class QStudentEnrollData
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentId { get; set; }
        public string CourseName { get; set; }
        public string Professor { get; set; }
        public string SemesterYear { get; set; }
    }
}
