using Application.Models;
using System.Threading.Tasks;
using Application.Requests.Users;

namespace Application.Interfaces.Users
{
    public interface IUserService : IBaseService<User, Domain.Entities.User, UserSearchRequest, UserInsertRequest, UserUpdateRequest>
    {
        public Task<User> GetByIdAsync(int id, string includeItems);
    }
}
