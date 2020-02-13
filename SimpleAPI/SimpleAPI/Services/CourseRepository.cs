using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models.QueryModels;
using System.Collections.Generic;
using SimpleAPI.Models.Enums;

namespace SimpleAPI.Services
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly DbSet<EnrolledIn> enrolledIn;
        private readonly DbSet<StudentData> students;
        private readonly DbSet<Activities> activities;

        public CourseRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
            enrolledIn = context.Set<EnrolledIn>();
            students = context.Set<StudentData>();
            activities = context.Set<Activities>();
        }

        public async Task<IEnumerable<QStudentsByCourse>> GetStudentsByCourseAsync(int id)
        {
            var studentList = await (from c in GetDbSet()
                                     join e in enrolledIn on c.Id equals e.CourseId
                                     join s in students on e.StudentId equals s.Id
                                     where c.Id == id
                                     select new QStudentsByCourse()
                                     {
                                         CourseName = c.CourseName,
                                         Professor = c.Professor,
                                         StudentId = s.StudentId,
                                         StudentName = s.StudentName
                                     })
                                     .ToListAsync();

            return studentList;
        }

        public async Task<IEnumerable<QActivitiesByCourse>> GetActivitiesByCourseAsync(int id)
        {
            var activityList = await (from c in GetDbSet()
                                      join a in activities on c.Id equals a.CourseId
                                      where c.Id == id
                                      select new QActivitiesByCourse()
                                      {
                                          CourseName = c.CourseName,
                                          DatePresented = a.DatePresented,
                                          ActivityType = (EActivityType)a.ActivityType
                                      })
                                      .ToListAsync();

            return activityList;
        }

        public async Task<bool> IsRecordExistentAsync(int id)
        {
            var c = await GetDbSet()
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return c != null;
        }

    }
}
