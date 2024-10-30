using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Security.Resources;

namespace Presentation.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="signUpResource">The user's registration data.</param>
        /// <returns>An action result indicating if the registration was successful.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] SignUpResource signUpResource)
        {
            return Ok();
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <param name="signInResource">The user's login data.</param>
        /// <returns>A message indicating if the login was successful.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] SignInResource signInResource)
        {
            return Ok(new { message = "User created successfully" });
        }
    }
}