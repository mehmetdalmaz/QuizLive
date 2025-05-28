using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuizLive.DTO.LoginDto;
using QuizLive.DTO.RegisterDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole<int>> roleManager,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userExits = await _userManager.FindByEmailAsync(model.Email);
            if (userExits != null)
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("User"));
            }
            await _userManager.AddToRoleAsync(user, "User");

            return Ok("Kayıt Başarılı");

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");

            var userRoles = await _userManager.GetRolesAsync(user);

            var token = GenerateJwtToken(user, userRoles);

            return Ok(new { token });
        }

        private string GenerateJwtToken(AppUser user, IList<string> roles)
        {
            var claims = new List<System.Security.Claims.Claim>
    {
        new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
        new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new System.Security.Claims.Claim("id", user.Id.ToString()),
        new System.Security.Claims.Claim("email", user.Email!)
    };

            // Roller claim olarak ekleniyor
            claims.AddRange(roles.Select(role => new System.Security.Claims.Claim("roles", role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}