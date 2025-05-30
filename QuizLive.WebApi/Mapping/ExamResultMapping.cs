using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.ExamResultDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class ExamResultMapping : Profile
    {
        public ExamResultMapping()
        {
            CreateMap<ExamResult, CreateExamResultDto>().ReverseMap();
            CreateMap<ExamResult, ResultExamResultDto>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName))

                .ForMember(dest => dest.ExamTitle, opt => opt.MapFrom(src => src.Exam.Title))
                .ReverseMap();
            CreateMap<ExamResult, UpdateExamResultDto>().ReverseMap();

        }
    }
}