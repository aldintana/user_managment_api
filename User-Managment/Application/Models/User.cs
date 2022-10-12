using System.Collections.Generic;

namespace Application.Models
{
    public class User : BaseModel<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
