using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class ActivitiesRepository : Repository<Activities>, IActivitiesRepository
    {
        public ActivitiesRepository(StudentsLoggerBaseContext context)
            :base(context)
        {
        }

        public async Task<IEnumerable<Activities>> GetAllByTypeAsync(EActivityType type)
        {
            var activities = await (from a in GetDbSet()
                                    where (EActivityType)a.ActivityType == type
                                    select a).ToListAsync();

            return activities;
        }

        public async Task<IEnumerable<Activities>> GetByCourseAsync(int courseId)
        {
            var activities = await (from a in GetDbSet()
                                    where a.CourseId == courseId
                                    select a).ToListAsync();

            return activities;
        }

        public async Task<IEnumerable<Activities>> GetByStudentAsync(int studentId)
        {
            var activities = await (from a in GetDbSet()
                                   where a.StudentId == studentId
                                   select a).ToListAsync();

            return activities;
        }
    }
}
