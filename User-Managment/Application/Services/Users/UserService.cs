using System;
using AutoMapper;
using System.Linq;
using System.Text;
using Application.Models;
using Application.Helpers;
using System.Threading.Tasks;
using Application.Requests.Users;
using System.Security.Cryptography;
using Application.Interfaces.Users;
using Application.Common.Interfaces;

namespace Application.Services.Users
{
    public class UserService : BaseService<User, UserSearchRequest, Domain.Entities.User, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        public UserService(IApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override async Task<PagedList<Domain.Entities.User, User>> GetAsync(UserSearchRequest searchRequest = null)
        {
            var entity = _context.Set<Domain.Entities.User>().AsQueryable();
            if(searchRequest != null)
            {
                if(!string.IsNullOrWhiteSpace(searchRequest.TextSearch))
                {
                    entity = entity.Where(e => 
                        e.FirstName.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.LastName.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.Email.ToLower().Contains(searchRequest.TextSearch.ToLower()) ||
                        e.Status.ToLower().Contains(searchRequest.TextSearch.ToLower())
                    );
                }
            }

            if (searchRequest.SortName != null && searchRequest.SortDirection != null)
            {
                var isAsc = searchRequest.SortDirection == "asc";
                var propertyName = entity.FirstOrDefault().GetType().GetProperty(searchRequest.SortName).Name;
                var firstEntity = entity.FirstOrDefault();
                if (nameof(firstEntity.FirstName) == propertyName)
                {
                    entity = isAsc ? entity.OrderBy(e => e.FirstName) : entity.OrderByDescending(e => e.FirstName);
                }
                else if(nameof(firstEntity.LastName) == propertyName)
                {
                    entity = isAsc ? entity.OrderBy(e => e.LastName) : entity.OrderByDescending(e => e.LastName);
                }
                else if (nameof(firstEntity.Email) == propertyName)
                {
                    entity = isAsc ? entity.OrderBy(e => e.Email) : entity.OrderByDescending(e => e.Email);
                }
                else if (nameof(firstEntity.Status) == propertyName)
                {
                    entity = isAsc ? entity.OrderBy(e => e.Status) : entity.OrderByDescending(e => e.Status);
                }
                else
                {
                    entity = entity.OrderBy(e => e.DateCreated);
                }
                
            }
            return await PagedList<Domain.Entities.User, User>.CreateAsync(entity,  _mapper, searchRequest.CurrentPage, searchRequest.PageSize);
        }

        public override async Task<User> InsertAsync(UserInsertRequest insertRequest)
        {
            var entity = _mapper.Map<Domain.Entities.User>(insertRequest);
            entity.DateCreated = DateTime.Now;
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, insertRequest.Password);

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<User>(entity);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
