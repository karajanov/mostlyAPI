using AutoMapper;
using SimpleAPI.Models;
using SimpleAPI.Models.DataTransferObjects;

namespace SimpleAPI.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ReverseMap();    
        }
    }
}
