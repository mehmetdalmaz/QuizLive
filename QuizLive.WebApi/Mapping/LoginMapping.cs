using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.LoginDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class LoginMapping : Profile
    {
        public LoginMapping()
        {
            CreateMap<AppUser, LoginDto>().ReverseMap();

        }
    }

}