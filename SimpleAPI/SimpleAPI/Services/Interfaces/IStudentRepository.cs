using SimpleAPI.Models;
using SimpleAPI.Models.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IStudentRepository : IRepository<StudentData>
    {

        Task<IEnumerable<QStudentActivityData>> GetStudentActivityDataAsync(int id);
        Task<IEnumerable<QStudentEnrollData>> GetStudentEnrollDataAsync(int id);
        Task<bool> IsStudentExistentAsync(int id);

    }
}
