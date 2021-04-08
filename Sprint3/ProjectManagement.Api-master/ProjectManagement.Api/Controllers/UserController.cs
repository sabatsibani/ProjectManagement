using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : BaseController<User>
    {
        private IUserService userSvc;
        private IMapper mappers;
        private readonly ApplicationConfig appSettings;

        public IBaseRepository<User> baseUserRepository { get; }

        public UserController(IBaseRepository<User> baseRepository) : base(baseRepository)
        {

        }
        //public UserController(
        //    IUserService userService,
        //    IMapper mapper,
        //    IOptions<ApplicationConfig> appSetting)
        //{
        //    userSvc = userService;
        //    mappers = mapper;
        //    appSettings = appSetting.Value;
        //}

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = userSvc.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = 
                new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = mappers.Map<User>(model);

            try
            {
                userSvc.Create(user, model.Password);
                return Ok();
            }
            catch (ApplicationError ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = userSvc.GetAll();
            var model = mappers.Map<IList<User>>(users);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = userSvc.GetById(id);
            var model = mappers.Map<User>(user);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<User>> DeleteUser(int id)
        {
            userSvc.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserModel model)
        {
            var user = mappers.Map<User>(model);
            user.Id = id;

            try
            {
                userSvc.Update(user, model.Password);
                return Ok();
            }
            catch (ApplicationError ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
