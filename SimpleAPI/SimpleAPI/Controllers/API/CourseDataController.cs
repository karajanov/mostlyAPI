using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Models.DataTransferObjects;
using SimpleAPI.Models.QueryModels;
using SimpleAPI.Services.Interfaces;

namespace SimpleAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDataController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;

        public CourseDataController(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")] // api/CourseData/{id}
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await courseRepository.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("All")] // api/CourseData/All
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await courseRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("Activities/{id}")]
        public async Task<IEnumerable<QActivitiesByCourse>> GetActivitiesByCourseAsync(int id)
        {
            return await courseRepository.GetActivitiesByCourseAsync(id);
        }

        [HttpGet("StudentList/{id}")]
        public async Task<IEnumerable<QStudentsByCourse>> GetListOfStudentsByCourseAsync(int id)
        {
            return await courseRepository.GetStudentsByCourseAsync(id);
        }

        [HttpPost] // api/CourseData
        public async Task<HttpResponseMessage> PostNewCourseAsync([FromBody] CourseViewModel cvm)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            try
            {
                var course = mapper.Map<Course>(cvm);
                await courseRepository.InsertAsync(course);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }

        [HttpPut("{id}")] // api/CourseData
        public async Task<HttpResponseMessage> PutExistingCourseAsync(int id, [FromBody] CourseViewModel cvm)
        {
            var isIdValid = await courseRepository.IsRecordExistentAsync(id);

            if (id == 0 || !isIdValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            if (!ModelState.IsValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            try
            {
                var course = mapper.Map<Course>(cvm);
                course.Id = id;
                await courseRepository.UpdateAsync(course);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{id}")] //api/CourseData
        public async Task<HttpResponseMessage> DeleteExistingCourseAsync(int id)
        {
            var isIdValid = await courseRepository.IsRecordExistentAsync(id);

            if (id == 0 || !isIdValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            try
            {
                await courseRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}