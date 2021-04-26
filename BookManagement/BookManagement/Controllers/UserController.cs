using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BookManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        LibraryContext _context;
        public UserController(IUserService userService, LibraryContext context)
        {
            _userService = userService;
            _context = context;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<User> Get(Guid id)
        {
            return _userService.GetById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(User user)
        {
            if (_userService.Create(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(Guid id, User user)
        {
            id = user.UserId;
            if (_userService.Update(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            if (_userService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            var result = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if (result != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,_context.Users
                                                      .Where(x=>x.Username ==user.Username && x.Password == user.Password)
                                                      .Single().Username),
                    new Claim(ClaimTypes.Role,_context.Users
                                                      .Where(x=>x.Username ==user.Username && x.Password == user.Password)
                                                      .Single().Role.ToString())

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
               // HttpContext.Session.SetString("userId",user.UserId.ToString());
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost("logout")]

        public async System.Threading.Tasks.Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Session.Remove("userId");
            return Ok();
        }
    }
}