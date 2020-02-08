using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;

namespace SimpleAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDataController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;

        public CourseDataController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

       [HttpPost] // api/CourseData?studentId=n&courseId=m
       public async Task<HttpResponseMessage> EnrollStudentAsync([FromQuery] int studentId, [FromQuery] int courseId)
        {
            if (studentId == 0 || courseId == 0)
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            try
            {
                await courseRepository.EnrollStudentAsync(studentId, courseId);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }


        //..soon
        //[HttpPost]
        //public async Task<HttpResponseMessage> EnrollStudentsAsync(int [] studentIds, int courseId)
        //{

        //}
    }
}