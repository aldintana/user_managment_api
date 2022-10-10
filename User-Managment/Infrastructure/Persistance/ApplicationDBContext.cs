using Domain.Entities;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override DbSet<TDb> Set<TDb>() where TDb : class
        {
            return base.Set<TDb>();
        }
    }
}
