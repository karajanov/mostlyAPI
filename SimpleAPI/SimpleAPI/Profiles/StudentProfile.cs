using AutoMapper;
using SimpleAPI.Models;
using SimpleAPI.Models.DataTransferObjects;

namespace SimpleAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentData, StudentViewModel>()
                .ReverseMap();
        }
    }
}
