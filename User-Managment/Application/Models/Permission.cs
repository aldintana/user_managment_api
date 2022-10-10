namespace Application.Models
{
    public class Permission : BaseModel<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
