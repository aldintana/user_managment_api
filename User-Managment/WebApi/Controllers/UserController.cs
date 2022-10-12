using Application.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Requests.Users;
using Application.Interfaces.Users;
using Application.Requests.UserPermissions;
using Application.Interfaces.UserPermissions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, Domain.Entities.User, UserSearchRequest, UserInsertRequest, UserUpdateRequest>
    {
        private IUserService _userService;
        private readonly IUserPermissionService _userPermissionsService;
        public UserController(IUserService service, IUserPermissionService userPermissionsService) : base(service)
        {
            _userService = service;
            _userPermissionsService = userPermissionsService;
        }

        [HttpGet("{id}/userPermissions")]
        public virtual async Task<IActionResult> GetUserPermissions(int id, [FromQuery] string includeItems)
        {
            return Ok(await _userService.GetByIdAsync(id, includeItems));
        }

        [HttpPost("userPermissions")]
        public virtual async Task<IActionResult> InsertUserPermissionAsync([FromBody] UserPermissionInsertRequest insertRequest)
        {
            return Ok(await _userPermissionsService.InsertAsync(insertRequest));
        }

        [HttpDelete("userPermissions/{userPermissionId}")]
        public virtual async Task<IActionResult> DeleteUserPermissionAsync(int userPermissionId)
        {
            return Ok(await _userPermissionsService.DeleteAsync(userPermissionId));
        }
    }
}
