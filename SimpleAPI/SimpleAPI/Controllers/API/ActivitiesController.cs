using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Models.Enums;
using SimpleAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepository activitiesRepository;

        public ActivitiesController(IActivitiesRepository activitiesRepository)
        {
            this.activitiesRepository = activitiesRepository;
        }

        [HttpGet]
        [Route("Type/{type}")] // api/Activities/Type/{type}
        public async Task<IEnumerable<Activities>> GetAllByTypeAsync(EActivityType type)
        {
            return await activitiesRepository.GetAllByTypeAsync(type);
        }

        [HttpGet]
        [Route("Student/{id}")] // api/Activities/Student/{id}
        public async Task<IEnumerable<Activities>> GetAllByStudentAsync(int id)
        {
            return await activitiesRepository.GetByStudentAsync(id);
        }

        [HttpGet]
        [Route("Course/{id}")] // api/Activities/Course/{id}
        public async Task<IEnumerable<Activities>> GetAllByTypeAsync(int id)
        {
            return await activitiesRepository.GetByCourseAsync(id);
        }

    }
}