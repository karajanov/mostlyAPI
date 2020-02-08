using SimpleAPI.Models;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<bool> EnrollStudentAsync(int studentId, int courseId);
        Task<bool> EnrollStudentsAsync(int[] studentIds, int courseId);
    }
}
