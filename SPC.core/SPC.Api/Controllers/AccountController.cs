using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SPC.Api.Autentication.Interface;
using SPC.Api.Controllers.DTO_s.Account;
using SPC.core.Entities;

namespace SPC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(ITokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Invalid login request.");
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password.");
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
                return Unauthorized("Invalid email or password.");
            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user, roles.ToList());
            return Ok(new { Token = token });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                return BadRequest("User already exists!");

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Initials = dto.Initials,
                SiteId = dto.SiteId,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "User");

            return Ok("Registration successful!");
        }
    }
}
