using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class StudentRepository : Repository<StudentData>, IStudentRepository
    {
        public StudentRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
        }

    }
}
