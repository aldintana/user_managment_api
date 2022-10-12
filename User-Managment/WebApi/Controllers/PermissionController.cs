using Application.Models;
using Application.Requests.Permissions;
using Application.Services.Permission;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : BaseController<Permission, Domain.Entities.Permission, object, PermissionInsertRequest, object>
    {
        public PermissionController(IPermissionService service) : base(service)
        {
        }
    }
}