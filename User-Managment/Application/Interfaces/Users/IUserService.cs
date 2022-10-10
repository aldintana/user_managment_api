using Application.Models;
using Application.Requests.Users;

namespace Application.Interfaces.Users
{
    public interface IUserService : IBaseService<User, UserSearchRequest, UserInsertRequest, UserUpdateRequest>
    {

    }
}
