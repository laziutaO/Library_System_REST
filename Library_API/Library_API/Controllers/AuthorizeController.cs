using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _options;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options.Value;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IResult> Register(RegisterDto registerRequest)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                IsBlocked = false
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
                return Results.BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "User");

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = GetToken(user);
            return Results.Ok(new
            {
                userName = user.UserName,
                email = user.Email,
                token = token.Result,
                roles = userRoles
            });
        }

        private async Task<string> GetToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email!)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IResult> LogIn(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null ||
                !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Results.Unauthorized();
            }

            if (user.IsBlocked)
                return Results.Forbid();

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return Results.Unauthorized();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var token = GetToken(user);
            return Results.Ok(new
            {
                userName = user.UserName,
                email = user.Email,
                token = token.Result,
                roles = userRoles
            });
    }
    }
}
