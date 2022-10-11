using System.ComponentModel.DataAnnotations;

namespace Application.Requests.Users
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Status { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
