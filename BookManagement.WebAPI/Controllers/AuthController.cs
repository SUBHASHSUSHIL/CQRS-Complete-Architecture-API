using BookManagement.WebAPI.Application.DTOs.Authentication;
using BookManagement.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;

        public AuthController(IAuthService authService, IMailService mailService)
        {
            _authService = authService;
            _mailService = mailService;
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignUpAsync([FromBody] RegisterRequest request)
        {
            try
            {
                if (request is null)
                    return BadRequest(new { Message = "Invalid register request" });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _authService.Register(request);

                if (!string.IsNullOrEmpty(user.Message))
                    return BadRequest(new { Message = user.Message });

                var token = user.EmailVerificationToken;
                var confirmationLink = Url.Action("ConfirmEmail", "Auth",
                    new { email = user.Email, token = token }, Request.Scheme);

                await _mailService.SendEmailConfirmationAsync(user.Email, confirmationLink);

                return Ok(new { Message = "Registration successful. Please check your email for confirmation." });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResult>> SignInAsync([FromBody] LoginRequest request)
        {
            try
            {
                if (request is null)
                    return BadRequest(new { Message = "Invalid login request" });

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.Login(request);
                return !string.IsNullOrEmpty(result.Message) ? BadRequest(new { Message = result.Message }) : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

    }
}
