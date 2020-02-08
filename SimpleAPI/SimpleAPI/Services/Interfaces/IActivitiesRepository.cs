using SimpleAPI.Models;
using SimpleAPI.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IActivitiesRepository : IRepository<Activities>
    {
        Task<IEnumerable<Activities>> GetAllByTypeAsync(EActivityType type);
        Task<IEnumerable<Activities>> GetByStudentAsync(int studentId);
        Task<IEnumerable<Activities>> GetByCourseAsync(int courseId);
    }
}
