namespace Application.Models
{
    public class UserPermission : BaseModel<int>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
