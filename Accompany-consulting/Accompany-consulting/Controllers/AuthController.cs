using Accompany_consulting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Accompany_consulting.Data;

namespace Accompany_consulting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ConsultantContext _context;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, ConsultantContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var existingEmailUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingEmailUser != null)
            {
                return BadRequest(" User existe déjà .");
            }


            var user = new User { Email = model.Email, UserName = model.UserName, NormalizedEmail = model.Email, Role = model.Role };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, model.Role);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Invalid credentials");
            }

            if (result.Succeeded)
            {
                var consultant = await _context.Consultants.FirstOrDefaultAsync(c => c.Mail == model.Email);
                if (consultant != null && consultant.Status == "actif")
                {
                    var token = new JwtSecurityToken(
                        issuer: "https://localhost:60734", // Mettez ici l'URL de votre serveur d'authentification
                        audience: "https://localhost:60734",
                        claims: new[]
                        {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                            // Ajoutez ici d'autres revendications personnalisées
                        },
                        expires: DateTime.UtcNow.AddHours(24),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")), SecurityAlgorithms.HmacSha256)
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { Token = tokenString , statut = consultant.Status });
                }
                else
                {
                    return StatusCode(403, "Consultant is not active");
                }
            }

            return Unauthorized();
        }

        [HttpGet("profile")]
        public async Task<IActionResult> UserProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound("User not found");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.Role,
                // Add here any additional profile information needed for your app
            });
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfile model)
        {
            // Récupérer l'utilisateur connecté
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'utilisateur
            user.UserName = model.UserName;
            user.Email = model.Email;

            // Enregistrer les modifications
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(string id)
        {
            if (!int.TryParse(id, out int userId))
            {
                return BadRequest("Invalid user ID");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found");
            }
            else { 
            return user;
            }
        }

        //get user by email 
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                return user;
            }
        }


        // ...

        [HttpGet("mailuser/{id}")]
        public async Task<ActionResult<string>> GetUserEmailByIdAsync(string id)
        {
            if (!int.TryParse(id, out int userId))
            {
                return BadRequest("Invalid user ID");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found");
            }

            return user.Email;
        }

        // ...

        [HttpPut("update-password/{id}")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto model, string id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return NotFound("User not found");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                var errors = changePasswordResult.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            return Ok();
        }




    }
}
public class UpdatePasswordDto
{
    [Required]
    public string CurrentPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
}
