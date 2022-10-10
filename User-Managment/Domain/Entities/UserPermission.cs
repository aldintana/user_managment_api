namespace Domain.Entities
{
    public class UserPermission : BaseEntity<int>
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
