using SimpleAPI.Models;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<bool> EnrollStudentAsync(int id);
        Task<bool> EnrollStudentsAsync(int[] ids);
    }
}
