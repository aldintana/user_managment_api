using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Requests.Users;
using Application.Interfaces.Users;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, Domain.Entities.User, UserSearchRequest, UserInsertRequest, UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
