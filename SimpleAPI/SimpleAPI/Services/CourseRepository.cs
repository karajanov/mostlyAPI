using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly IStudentRepository studentRepository;
        private readonly IEnrolledInRepository enrolledInRepository;

        public CourseRepository(StudentsLoggerBaseContext context, IStudentRepository studentRepository,
            IEnrolledInRepository enrolledInRepository)
            :base(context)
        {
            this.studentRepository = studentRepository;
            this.enrolledInRepository = enrolledInRepository;
        }

        public async Task<bool> EnrollStudentAsync(int studentId, int courseId)
        {
           
            var enrolledInInfo = new EnrolledIn()
            {
                StudentId = studentId,
                CourseId = courseId,
                StudentYear = System.DateTime.Now.Year.ToString()
            };

            try
            {
                await enrolledInRepository.InsertAsync(enrolledInInfo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> EnrollStudentsAsync(int[] studentIds, int courseId)
        {
    
            foreach (var item in studentIds)
            {
                var existingStudent = await studentRepository.GetByIdAsync(item);

                if (existingStudent != null)
                {
                    var enrolledInInfo = new EnrolledIn()
                    {
                        StudentId = item,
                        CourseId = courseId,
                        StudentYear = System.DateTime.Now.Year.ToString()
                    };

                    try
                    {
                        await enrolledInRepository.InsertAsync(enrolledInInfo);
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
            }

            return true;
        }

    }
}
