using Application.Interfaces;
using Application.Requests.Permissions;

namespace Application.Services.Permission
{
    public interface IPermissionService : IBaseService<Models.Permission, Domain.Entities.Permission, object, PermissionInsertRequest, object>
    {
    }
}