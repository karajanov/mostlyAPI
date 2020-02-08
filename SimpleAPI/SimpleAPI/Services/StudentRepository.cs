using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;
using SimpleAPI.Models.QueryModels;
using SimpleAPI.Services.Interfaces;
using System.Linq;
using SimpleAPI.Models.Enums;

namespace SimpleAPI.Services
{
    public class StudentRepository : Repository<StudentData>, IStudentRepository
    {
        private readonly DbSet<Activities> activities;
        private readonly DbSet<EnrolledIn> enrolledIn;
        private readonly DbSet<Course> course;

        public StudentRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
            activities = context.Set<Activities>();
            enrolledIn = context.Set<EnrolledIn>();
            course = context.Set<Course>();
        }

        
        public async Task<IEnumerable<QStudentActivityData>> GetStudentActivityDataAsync(int id)
        {
            var data = await (from s in GetDbSet()
                              join a in activities on s.Id equals a.StudentId
                              join c in course on a.CourseId equals c.Id
                              where s.Id == id
                              select new QStudentActivityData()
                              {
                                  StudentId = s.StudentId,
                                  StudentEmail = s.StudentEmail,
                                  StudentName = s.StudentName,
                                  CourseName = c.CourseName,
                                  DatePresented = a.DatePresented,
                                  ActivityType = (EActivityType)a.ActivityType
                              }).ToListAsync();

            return data;
        }

        public async Task<IEnumerable<QStudentEnrollData>> GetStudentEnrollDataAsync(int id)
        {
            var data = await (from s in GetDbSet()
                              join e in enrolledIn on s.Id equals e.StudentId
                              join c in course on e.CourseId equals c.Id
                              where s.Id == id
                              select new QStudentEnrollData()
                              {
                                  StudentId = s.StudentId,
                                  StudentName = s.StudentName,
                                  StudentEmail = s.StudentEmail,
                                  CourseName = c.CourseName,
                                  Professor = c.Professor,
                                  SemesterYear = c.SemesterYear
                              }
                        ).ToListAsync();

            return data;
        }

        public async Task<bool> IsStudentExistentAsync(int id)
        {
            var s = await GetDbSet()
                .FirstOrDefaultAsync(s => s.Id == id);

            return s != null;
        }

    }
}
