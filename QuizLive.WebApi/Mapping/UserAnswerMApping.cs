using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.UserAnswerDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class UserAnswerMApping : Profile
    {
        public UserAnswerMApping()
        {
            CreateMap<UserAnswer, CreateUserAnswerDto>().ReverseMap();
            CreateMap<UserAnswer, UpdateUserAnswerDto>().ReverseMap();
            CreateMap<UserAnswer, ResultUserAnswerDto>().ReverseMap();
        }

    }
}