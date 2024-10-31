using Domain.Security.Model.Commands;
using Domain.Security.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Security.Resources;
using Presentation.Security.Transform;

namespace Presentation.Security.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserCommandService _userCommandService;

        public AuthenticationController(IUserCommandService userCommandService)
        {
            _userCommandService = userCommandService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="signUpResource">The user's registration data.</param>
        /// <returns>An action result indicating if the registration was successful.</returns>
        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SignUpCommand), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] SignUpResource signUpResource)
        {
            var command = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);

            await _userCommandService.Handle(command);

            return StatusCode(201, command);
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <param name="signInResource">The user's login data.</param>
        /// <returns>A message indicating if the login was successful.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] SignInResource signInResource)
        {
            return Ok(new { message = "User created successfully" });
        }
    }
}