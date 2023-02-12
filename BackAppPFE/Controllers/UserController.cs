using BackAppPFE.Context;
using BackAppPFE.Helpers;
using BackAppPFE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using System.Data;
using System.Net.Http.Headers;


namespace BackAppPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly AppDbContext _authContext;
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _authContext = appDbContext;
        }

        

        [HttpPost("authentificate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.Username == userObj.Username);
            if (user == null)
                return NotFound(new { Message = "User Not Found!" });
            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }


            user.Token = CreateToken(user);
            //user.Token = CreateJwt(user);

             return Ok(new
             {
                 Token = user.Token,
                 Message = "Login Success!"
             }); 
            //return Ok(token);
        }

        //create new token
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }




        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            //check username 
            if (await CheckUserNameExistAsync(userObj.Username))
                return BadRequest(new { Message = "Username Already Exist!" });
            //check email
            if (await CheckEmailExistAsync(userObj.Email))
                return BadRequest(new { Message = "Email Already Exist!" });
            //check password
            var pass = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });


            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            //userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });
        }

        private Task<bool> CheckUserNameExistAsync(string username)
          => _authContext.Users.AnyAsync(x => x.Username == username);

        private Task<bool> CheckEmailExistAsync(string email)
          => _authContext.Users.AnyAsync(x => x.Email == email);
        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum password lenght should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,`,-,=]"))
                sb.Append("Password should contain special chars" + Environment.NewLine);
            return sb.ToString();
        }

        //create token
        /*
      private string CreateJwt(User user)
         {
             var jwtTokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes("verysceret");
             var identity = new ClaimsIdentity(new Claim[]
             {
                 new Claim(ClaimTypes.Role, user.Role),
                 new Claim(ClaimTypes.Name,$"{user.LastName}")
             });

             var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = identity,
                 //token valid for 1 day
                 Expires = DateTime.Now.AddDays(1),
                 SigningCredentials = credentials
             };
             var token = jwtTokenHandler.CreateToken(tokenDescriptor);
             return jwtTokenHandler.WriteToken(token);

         } 

          */
        //get all users
        [HttpGet]
         public async Task<ActionResult<User>> GetAllUsers()
         {
             return Ok(await _authContext.Users.ToListAsync());
         }

        //crud
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                Username = addUserRequest.Username,
                Password = addUserRequest.Password,
                Email = addUserRequest.Email,
                Role = addUserRequest.Role,
                Token = addUserRequest.Token
            };
            user.Password = PasswordHasher.HashPassword(user.Password);
            await _authContext.Users.AddAsync(user);
            await _authContext.SaveChangesAsync();
            
            

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id,UpdateUserRequest updateUserRequest)
        {
            var user = await _authContext.Users.FindAsync(id);
            if (User != null)
            {
                user.FirstName = updateUserRequest.FirstName;
                user.LastName = updateUserRequest.LastName;
                user.Username = updateUserRequest.Username;
                user.Password = updateUserRequest.Password;
                user.Email = updateUserRequest.Email;
                user.Role = updateUserRequest.Role;
                user.Token = updateUserRequest.Token;

                user.Password = PasswordHasher.HashPassword(user.Password);
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _authContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _authContext.Users.FindAsync(id);
            if (user != null)
            {
                _authContext.Remove(user);
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }

}
