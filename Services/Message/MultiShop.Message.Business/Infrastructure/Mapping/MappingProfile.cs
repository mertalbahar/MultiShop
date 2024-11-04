using AutoMapper;
using MultiShop.Message.Dto.Dtos;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateUserMessageDto>().ReverseMap();
        }
    }
}
