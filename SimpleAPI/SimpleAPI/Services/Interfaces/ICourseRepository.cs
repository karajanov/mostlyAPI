using SimpleAPI.Models;
using SimpleAPI.Models.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface ICourseRepository : IRepository<Course>, IRecordExistence
    {
        Task<IEnumerable<QStudentsByCourse>> GetStudentsByCourseAsync(int id);
        Task<IEnumerable<QActivitiesByCourse>> GetActivitiesByCourseAsync(int id);
    }
}
