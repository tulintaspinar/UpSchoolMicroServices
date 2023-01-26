using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.IdentityServer.DTOs;
using UpSchoolECommerce.IdentityServer.Models;
using UpSchoolECommerce.Shared.DTOs;
using static IdentityServer4.IdentityServerConstants;

namespace UpSchoolECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                City= signUpDTO.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest(ResponseDTO<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(),400));
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userId.Value);
            return Ok(new
            {
                Id=user.Id,
                UserName=user.UserName,
                Email=user.Email,
                City=user.City
            });
        }
    }
}
