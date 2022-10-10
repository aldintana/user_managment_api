using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, Models.User>().ReverseMap();
            CreateMap<Permission, Models.Permission>().ReverseMap();
        }
    }
}
