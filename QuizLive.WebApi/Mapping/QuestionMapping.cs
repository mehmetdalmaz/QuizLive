using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.OptionDto;
using QuizLive.DTO.QuestionDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping()
        {
            CreateMap<Question, ResultQuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ReverseMap();
            CreateMap<Question, CreateQuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ReverseMap();
            CreateMap<Question, UpdateQuestionDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                .ReverseMap();
            CreateMap<CreateOptionDto, Option>().ReverseMap();
            CreateMap<UpdateOptionDto, Option>().ReverseMap();
            CreateMap<Option, ResultOptionDto>().ReverseMap();

        }
    }
}