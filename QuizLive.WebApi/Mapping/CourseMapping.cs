using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.CourseDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<Course, ResultCourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
               
        }
        
    }
}