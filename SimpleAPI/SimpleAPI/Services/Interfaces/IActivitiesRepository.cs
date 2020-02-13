using SimpleAPI.Models;
using SimpleAPI.Models.Enums;
using SimpleAPI.Models.QueryModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IActivitiesRepository : IRepository<Activities>
    {
        Task<IEnumerable<QActivitiesByType>> GetAllByTypeAsync(EActivityType type);        
    }
}
