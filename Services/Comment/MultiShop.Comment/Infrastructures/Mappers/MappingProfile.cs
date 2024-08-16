using AutoMapper;
using MultiShop.Comment.Dtos.ContactDtos;
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

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
