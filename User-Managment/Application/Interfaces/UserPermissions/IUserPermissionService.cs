using Application.Models;

namespace Application.Interfaces.UserPermissions
{
    public interface IUserPermissionService : IBaseService<UserPermission, Domain.Entities.UserPermission, object, Application.Requests.UserPermissions.UserPermissionInsertRequest, object>
    {
    }
}
