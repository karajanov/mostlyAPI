using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
        }

        public Task<bool> EnrollStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnrollStudentsAsync(int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
