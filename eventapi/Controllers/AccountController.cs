using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eventapi.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using petApi.Data.IRepository;
using petApi.Models;

namespace eventapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserRepository userRepository, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _config = config;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">the login details</param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string id = _userRepository.GetByUsername(model.UserName).Id.ToString();
                    string token = GetToken(user, id);
                    return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model">the user details</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            IdentityUser user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            User usr = new User()
            {
                Username = model.UserName,
                Email = model.Email,
                Surename = model.Surename,
                Familyname = model.Familyname
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "USER"));
            await _userManager.AddToRoleAsync(user, "USER");

            if (result.Succeeded)
            {
                _userRepository.AddUser(usr);
                _userRepository.SaveChanges();
                string id = _userRepository.GetByUsername(model.UserName).Id.ToString();
                string token = GetToken(user, id);
                return Created("", token);
            }
            return BadRequest();
        }

        /// <summary>
        /// Checks if an username is available
        /// </summary>
        /// <returns>true if the username is not registered yet</returns>
        /// <param name="email">Email.</param>/
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user == null;
        }

        /// <summary>
        /// Checks if an email is available as username
        /// </summary>
        /// <returns>true if the email is not registered yet</returns>
        /// <param name="email">Email.</param>/
        [AllowAnonymous]
        [HttpGet("checkemail")]
        public async Task<ActionResult<Boolean>> CheckAvailableEmaile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }

        private String GetToken(IdentityUser user, string id)
        {
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
              new Claim("Id", id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}