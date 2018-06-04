using BlueCinema.Models.ViewModels;
using BlueCinema.Security;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlueCinema.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMessageService _messageService;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMessageService messageService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._messageService = messageService;
        }

        public IActionResult Register()
        {
            return Ok("Empty register");
        }

        [HttpGet("{id}")]
        [Route("api/account/get")]
        public IActionResult GetAll(int id)
        {
            return Ok("Empty register" + id);
        }

        [Authorize(Roles = "Administrator")]
        [Route("api/account/admin")]
        public IActionResult RequiresAdmin()
        {
            return Ok("OK");
        }

        [HttpPost]
        [Route("api/account/register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            if (registerViewModel.Password != registerViewModel.RePassword)
            {
                return BadRequest("Password don't match");
            }

            var newUser = new IdentityUser
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };
            try
            {
                var userCreationResult = await _userManager.CreateAsync(newUser, registerViewModel.Password);
                if (!userCreationResult.Succeeded)
                {
                    return BadRequest(userCreationResult.Errors.Select(e => e.Description));
                }
                await _userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.Role, "User"));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            //var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            //var tokenVerificationUrl = Url.Action("VerifyEmail", "Account", new { id = newUser.Id, token = emailConfirmationToken }, Request.Scheme);

            //await _messageService.Send(registerViewModel.Email, "Verify your email", $"Click <a href=\"{tokenVerificationUrl}\">here</a> to verify your email");

            //return Ok("Check your email for a verification link");
            return Ok("Ok, account created");

        }

        [HttpPost]
        [Route("api/account/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                return BadRequest("Invalid login");
            }
            //if (!user.EmailConfirmed)
            //{
            //    return BadRequest("Confirm your email first");
            //}

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                return BadRequest("Invalid login");
            }

            var claims = await _userManager.GetClaimsAsync(user);

            return Ok(new { token = JWTTokenCreator.GetToken(loginViewModel, claims), claims = claims, uid = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody]string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Ok("Check your email for a password reset link");

            var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetUrl = Url.Action("ResetPassword", "Account", new { id = user.Id, token = passwordResetToken }, Request.Scheme);

            await _messageService.Send(email, "Password reset", $"Click <a href=\"" + passwordResetUrl + "\">here</a> to reset your password");

            return Ok("Check your email for a password reset link");
        }

        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException();

            var emailConfirmationResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!emailConfirmationResult.Succeeded)
                return Content(emailConfirmationResult.Errors.Select(error => error.Description).Aggregate((allErrors, error) => allErrors += ", " + error));

            return Ok("Email confirmed, you can now log in");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, string token, string password, string repassword)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException();

            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match");
                return View();
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, password);
            if (!resetPasswordResult.Succeeded)
            {
                foreach (var error in resetPasswordResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            return Content("Password updated");
        }

    }
}