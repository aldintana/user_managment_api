using Application.Common.Interfaces;
using Application.Interfaces.UserPermissions;
using Application.Models;
using Application.Requests.UserPermissions;
using AutoMapper;

namespace Application.Services.UserPermissions
{
    public class UserPermissionsService : BaseService<UserPermission, object, Domain.Entities.UserPermission, UserPermissionInsertRequest, object>, IUserPermissionService
    {
        public UserPermissionsService(IApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}