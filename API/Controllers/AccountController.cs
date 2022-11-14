using System.Security.Claims;
using API.Extensions;
using Application.Dtos.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var currentUser = await _accountService.GetCurrentUser(email);

            return Ok(currentUser);
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExists([FromQuery] string email)
        {
            return await _accountService.CheckEmailExists(email);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var login = await _accountService.Login(loginDto);
            return Ok(login);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var register = await _accountService.Register(registerDto);
            return Ok(register);
        }

        [HttpPut("update-password")]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordDto updatePassword)
        {
            await _accountService.UpdatePassword(updatePassword.OldPassword, 
            updatePassword.NewPassword, GetEmail());

            return Ok();
        }

        [HttpPut("update-email")]
        public async Task<ActionResult> UpdateEmail(UpdateEmailDto updateEmail)
        {
            await _accountService.UpdateEmail(updateEmail.Email, updateEmail.Token, GetEmail());

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string email)
        {
            await _accountService.DeleteCurrentUser(email);

            return NoContent();
        }

        private string GetEmail()
        {
            return HttpContext.User.RetrieveEmailFromPrincipal();
        }
    }
}