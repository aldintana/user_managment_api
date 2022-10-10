namespace Domain.Entities
{
    public class Permission : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
