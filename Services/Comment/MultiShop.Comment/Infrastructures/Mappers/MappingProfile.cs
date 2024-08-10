using AutoMapper;
using MultiShop.Comment.Dtos.UserCommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Infrastructures.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserComment, ResultUserCommentDto>().ReverseMap();
            CreateMap<UserComment, GetByIdUserCommentDto>().ReverseMap();
            CreateMap<UserComment, CreateUserCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateUserCommentDto>().ReverseMap();
        }
    }
}
