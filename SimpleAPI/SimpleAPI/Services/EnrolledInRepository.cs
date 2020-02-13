using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class EnrolledInRepository : Repository<EnrolledIn>, IEnrolledInRepository
    {
        public EnrolledInRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
        }

        public async Task<bool> EnrollStudentAsync(int studentId, int courseId)
        {

            //var enrolledInInfo = new EnrolledIn()
            //{
            //    StudentId = studentId,
            //    CourseId = courseId,
            //    StudentYear = System.DateTime.Now.Year.ToString()
            //};

            //try
            //{
            //    await enrolledInRepository.InsertAsync(enrolledInInfo);
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            return true;
        }

        public async Task<bool> EnrollStudentsAsync(int[] studentIds, int courseId)
        {

            //foreach (var item in studentIds)
            //{
            //    var existingStudent = await studentRepository.GetByIdAsync(item);

            //    if (existingStudent != null)
            //    {
            //        var enrolledInInfo = new EnrolledIn()
            //        {
            //            StudentId = item,
            //            CourseId = courseId,
            //            StudentYear = System.DateTime.Now.Year.ToString()
            //        };

            //        try
            //        {
            //            await enrolledInRepository.InsertAsync(enrolledInInfo);
            //        }
            //        catch (Exception)
            //        {
            //            return false;
            //        }

            //    }
            //}

            return true;
        }
    }
}
