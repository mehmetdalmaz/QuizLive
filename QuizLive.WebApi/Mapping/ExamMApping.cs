using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.ExamDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class ExamMApping : Profile
    {
        public ExamMApping()
        {
            CreateMap<Exam, ResultExamDto>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name)).ReverseMap();
            CreateMap<Exam, CreateExamDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId)).ReverseMap();
            CreateMap<Exam, UpdateExamDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DurationInMinutes, opt => opt.MapFrom(src => src.DurationInMinutes))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId)).ReverseMap();
        }
        
    }
}