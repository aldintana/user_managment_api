using AutoMapper;
using Application.Models;
using Application.Requests.Users;
using Application.Interfaces.Users;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace Application.Services.Users
{
    public class UserService : BaseService<User, UserSearchRequest, Domain.Entities.User, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        public UserService(IApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override async Task<IEnumerable<User>> GetAsync(UserSearchRequest searchRequest = null)
        {
            var entity = _context.Set<Domain.Entities.User>().AsQueryable();
            if(searchRequest != null)
            {
                if(string.IsNullOrWhiteSpace(searchRequest.TextSearch))
                {
                    entity = entity.Where(e => 
                        e.FirstName.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.LastName.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.Email.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.Status.ToLower().Contains(searchRequest.TextSearch.ToLower())
                    );
                }
            }

            var list = entity.ToList();

            return _mapper.Map<List<User>>(list);
        }
    }
}
