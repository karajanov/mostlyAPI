using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Models.DataTransferObjects;
using SimpleAPI.Models.QueryModels;
using SimpleAPI.Services.Interfaces;

namespace SimpleAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentDataController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Plain/{id}")] // api/StudentData/Plain/{id}
        public async Task<StudentData> GetPlainStudentDataAsync(int id)
        {
            return await studentRepository.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("Plain/All")] // api/StudentData/Plain/All
        public async Task<IEnumerable<StudentData>> GetAllPlainStudentDataAsync()
        {
            return await studentRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("Enroll/{id}")] // api/StudentData/Enroll/{id}
        public async Task<IEnumerable<QStudentEnrollData>> GetStudentEnrollDataAsync(int id)
        {
            return await studentRepository.GetStudentEnrollDataAsync(id);
        }

        [HttpGet]
        [Route("Activity/{id}")] // api/StudentData/Activity/{id}
        public async Task<IEnumerable<QStudentActivityData>> GetStudentActivityDataAsync(int id)
        {
            return await studentRepository.GetStudentActivityDataAsync(id);
        }

        [HttpPost] // api/StudentData
        public async Task<HttpResponseMessage> PostNewStudentDataAsync([FromBody] StudentViewModel svm)
        {
            if (!ModelState.IsValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            try
            {
                var student = mapper.Map<StudentData>(svm);
                await studentRepository.InsertAsync(student);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);

        }

        [HttpPut("{id}")] // api/StudentData/{id}
        public async Task<HttpResponseMessage> PutExistingStudentDataAsync(int id, [FromBody] StudentViewModel svm)
        {
            if (id == 0)
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            if (!ModelState.IsValid)
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            try
            {
                var student = mapper.Map<StudentData>(svm);
                student.Id = id;
                await studentRepository.UpdateAsync(student);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [HttpDelete("{id}")] // api/StudentData/{id}
        public async Task<HttpResponseMessage> DeleteExistingStudentDataAsync(int id)
        {
            if (id == 0)
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

            try
            {
                await studentRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}