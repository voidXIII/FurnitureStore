using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.User
{
    public class UpdateEmailDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
    }
}