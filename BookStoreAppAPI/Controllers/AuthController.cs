using AutoMapper;
using BookStoreAppAPI.Data;
using BookStoreAppAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IMapper mapper;
        private readonly UserManager<ApiUser> userManager;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<ApiUser> userManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            logger.LogInformation($"my:Registration Attempt for {userDto.Email}");
            try {
                var user = mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded == false)
                {
                    /*foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }*/
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, "User");
                return Accepted();
            } catch (Exception ex) {
                logger.LogError(ex, $"my:Something Went Wrong in the {nameof(Register)}");
                return Problem($"my:Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login (LoginUserDto userDto)
        {
            logger.LogInformation($"my:Login Attempt for {userDto.Email}");
            try
            {
                var user = await userManager.FindByEmailAsync(userDto.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, userDto.Password);
                if (user == null || passwordValid == false)
                {
                    return NotFound();
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"my:Something Went Wrong in the {nameof(Login)}");
                return Problem($"my:Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
