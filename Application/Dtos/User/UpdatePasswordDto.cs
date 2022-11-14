using System.ComponentModel.DataAnnotations;


namespace Application.Dtos.User
{
    public class UpdatePasswordDto
    {
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$",
            ErrorMessage = "Password should be created from minimum six characters, at least one letter, one number and one special character.")]
        public string OldPassword { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$",
            ErrorMessage = "Password should be created from minimum six characters, at least one letter, one number and one special character.")]
        public string NewPassword { get; set; }
    }
}