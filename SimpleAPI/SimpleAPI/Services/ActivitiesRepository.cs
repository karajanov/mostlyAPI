using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;
using SimpleAPI.Models.Enums;
using SimpleAPI.Models.QueryModels;
using SimpleAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class ActivitiesRepository : Repository<Activities>, IActivitiesRepository
    {
        private readonly DbSet<StudentData> students;
        private readonly DbSet<Course> course;

        public ActivitiesRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
            students = context.Set<StudentData>();
            course = context.Set<Course>();
        }

        public async Task<IEnumerable<QActivitiesByType>> GetAllByTypeAsync(EActivityType type)
        {

            var activities = await (from a in GetDbSet()
                                    join c in course on a.CourseId equals c.Id
                                    join s in students on a.StudentId equals s.Id
                                    where (EActivityType)a.ActivityType == type
                                    select new QActivitiesByType()
                                    {
                                        StudentName = s.StudentName,
                                        CourseName = c.CourseName,
                                        DatePresented = a.DatePresented,
                                        ActivityType = (EActivityType)a.ActivityType
                                    })
                                    .ToListAsync();

            return activities;
        }

    }
}
