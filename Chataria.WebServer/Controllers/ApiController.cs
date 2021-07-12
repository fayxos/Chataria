using Chataria.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chataria.WebServer.Controllers
{
    /// <summary>
    /// Manages the Web API calls
    /// </summary>
    public class ApiController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDbContext mContext;

        /// <summary>
        /// The manager for handling users creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"> The injected context</param>
        /// <param name="signInManager">The Identity sign in manager</param>
        /// <param name="userManager">The Identity user manager</param>
        public ApiController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LogInAsync([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            // TODO: Localize all strings
            var invalidErrorMessage = "Invalid username or password";

            // The error response for a failed login
            var errorResponse = new ApiResponse<LoginResultApiModel>
            {
                // Set error message
                ErrorMessage = invalidErrorMessage
            };

            // Make sure we have a user name
            if (loginCredentials?.UsernameOrEmail == null || string.IsNullOrWhiteSpace(loginCredentials.UsernameOrEmail))
                // Return the error message to the user
                return errorResponse;

            // Validate if the user credentials are correct

            // Is it an email?
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");

            // Get the user details
            var user = isEmail ?
                // Find by email
                await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) :
                // Find by username
                await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            
            // If it failed to find a user...
            if(user == null)
                // Return the error message to the user
                return errorResponse;

            // There is a user ->
            // Validate the password

            // Get if password is valid
            var isValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);

            // If the password was wrong
            if(!isValidPassword)
                // Return the error message to the user
                return errorResponse;

            // Valid user and password ->

            // Get username
            var username = user.UserName;

            // Set our tokens claims
            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                // Get the secret key from configuration
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"])),
                // Use HS256 algorithm
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                issuer: IoCContainer.Configuration["Jwt:Issuer"],
                audience: IoCContainer.Configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: credentials,
                // Expire if not used for 3 months
                expires: DateTime.Now.AddMonths(3)
                );

            // Return token to user
            return new ApiResponse<LoginResultApiModel>
            {
                // Pass back the user details and the token
                Response = new LoginResultApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            };
        }

        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;

            return Ok(new { privateData = $"some secret for {user.Identity.Name}" });
        }
    }
}
