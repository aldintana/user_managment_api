using Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<UserPermission> UserPermissions { get; set; }
        Task<int> SaveChangesAsync();
        DbSet<TDb> Set<TDb>() where TDb : class;
    }
}
