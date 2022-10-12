using AutoMapper;
using Domain.Entities;
using Application.Requests.Users;
using Application.Requests.Permissions;
using Application.Requests.UserPermissions;

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
            CreateMap<Permission, PermissionInsertRequest>().ReverseMap();
            CreateMap<PermissionInsertRequest, Models.Permission>().ReverseMap();
            CreateMap<UserPermission, Models.UserPermission>().ReverseMap();
            CreateMap<UserPermissionInsertRequest, UserPermission>().ReverseMap();
            CreateMap<UserPermissionInsertRequest, Models.Permission>().ReverseMap();
        }
    }
}
