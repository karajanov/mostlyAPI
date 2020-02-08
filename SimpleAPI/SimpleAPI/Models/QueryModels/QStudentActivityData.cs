using SimpleAPI.Models.Enums;
using System;

namespace SimpleAPI.Models.QueryModels
{
    public class QStudentActivityData
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentId { get; set; }
        public string CourseName { get; set; }
        public DateTime? DatePresented { get; set; }
        public EActivityType? ActivityType { get; set; }
    }
}
