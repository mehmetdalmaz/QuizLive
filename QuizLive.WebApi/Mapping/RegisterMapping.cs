using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuizLive.DTO.RegisterDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Mapping
{
    public class RegisterMapping: Profile
    {
        public RegisterMapping()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}