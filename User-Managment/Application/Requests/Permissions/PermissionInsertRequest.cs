using System.ComponentModel.DataAnnotations;

namespace Application.Requests.Permissions
{
    public class PermissionInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
