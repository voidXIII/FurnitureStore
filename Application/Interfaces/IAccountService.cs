using Application.Dtos.User;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> GetCurrentUser(string email);
        Task<bool> CheckEmailExists(string email);
        Task<UserDto> Login(LoginDto loginDTO);
        Task<UserDto> Register(RegisterDto registerDTO);
        Task<UserDto> UpdatePassword(string oldPassword, string newPassword, string email);
        Task<UserDto> UpdateEmail(string email, string token, string currentEmail);
    }
}