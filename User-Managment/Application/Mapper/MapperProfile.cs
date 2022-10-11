using AutoMapper;
using Domain.Entities;
using Application.Requests.Users;

namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, Models.User>().ReverseMap();
            CreateMap<User, UserInsertRequest>().ReverseMap();
            CreateMap<User, UserUpdateRequest>().ReverseMap();
            CreateMap<UserInsertRequest, Models.User>().ReverseMap();
            CreateMap<UserUpdateRequest, Models.User>().ReverseMap();
            CreateMap<Permission, Models.Permission>().ReverseMap();
        }
    }
}
