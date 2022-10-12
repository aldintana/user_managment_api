using AutoMapper;
using Application.Common.Interfaces;
using Application.Requests.Permissions;

namespace Application.Services.Permission
{
    public class PermissionService : BaseService<Models.Permission, object, Domain.Entities.Permission, PermissionInsertRequest, object>, IPermissionService
    {
        public PermissionService(IApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}