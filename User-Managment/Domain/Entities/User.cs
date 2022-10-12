using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }

    }
}
