using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.User
{
    public class UserDetailsDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }
}