using System.Security.Claims;
using Application.Dtos.User;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task DeleteCurrentUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("User with this email doesn't exist.");
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task<UserDto> GetCurrentUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = _userManager.GetClaimsAsync(user).Result[0].Value;

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user, role),
                DisplayName = user.DisplayName
            };
        }

        public async Task<UserDto> Login(LoginDto loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Wrong email, please try again.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            var role = _userManager.GetClaimsAsync(user).Result[0].Value;

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Password don't match, please try again.");
            }

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user, role),
                DisplayName = user.DisplayName
            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            if (await CheckEmailExists(registerDto.Email))
            {
                throw new UnauthorizedAccessException("Email address in use!");
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Registered User")).GetAwaiter().GetResult();
            }

            if (!result.Succeeded) 
            {
                throw new UnauthorizedAccessException("Error on registration process.");
            }
            
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user, "Registered User"),
                Email = user.Email
            };
        }

        public async Task<UserDto> UpdateEmail(string email, string token, string currentEmail)
        {
            var currentUser = await GetUser(currentEmail);

            if (await CheckEmailExists(email))
            {
                throw new UnauthorizedAccessException("Email address in use!");
            }

            var result = await _userManager.ChangeEmailAsync(currentUser, email, token);

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Error on changing email.");
            }

            return new UserDto
            {
                Email = currentUser.Email,
                DisplayName = currentUser.DisplayName,
                Token = _tokenService.CreateToken(currentUser, "Registered User")
            };
        }

        public async Task<UserDto> UpdatePassword(string oldPassword, string newPassword, string email)
        {
            var user = await GetUser(email);

            if (!await CheckEmailExists(user.Email))
            {
                throw new UnauthorizedAccessException("Your are not authorized!");
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Error on changing password.");
            }

            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user, "Registered User")
            };
        }

        private async Task<AppUser> GetUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}