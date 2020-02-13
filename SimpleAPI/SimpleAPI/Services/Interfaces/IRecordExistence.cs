using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IRecordExistence
    {
        Task<bool> IsRecordExistentAsync(int id);
    }
}
