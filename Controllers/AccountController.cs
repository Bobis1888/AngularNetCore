using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AngularDotnetCore.Models;
using AngularDotnetCore.Services;

namespace AngularDotnetCore.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }
        private AccountService accountService;
        [HttpPost]
        [Route("login")]
        // TODO [ValidateAntiForgeryToken]
        public IActionResult Login(User aUser)
        {
            if (ModelState.IsValid)
            {
                aUser = Authenticate(aUser).Result;
                return Ok(aUser);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("registration")]
        // TODO [ValidateAntiForgeryToken]
        public IActionResult Registration(User aUser)
        {
            if(ModelState.IsValid)
            {
                aUser = CreateUser(aUser).Result;
                return Ok(aUser);
            }
            return BadRequest(ModelState);
        }
        private async Task<User> Authenticate(User aUser)
        {
            var user = accountService.FindUser(aUser).Result;
            if(user != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimsIdentity.DefaultNameClaimType,aUser.Email)
                };
                var id = new ClaimsIdentity(claims,"ApplicationCookie",ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                aUser.Trusted = true;
            }
            else
            {
                aUser = new User();
            }
            return aUser;
        }
        private async Task<User> CreateUser(User aUser)
        {
            var user = accountService.CheckEmail(aUser).Result;
            if(user == null)
            {
                aUser = await accountService.CreateUser(aUser);
            }
            else
            {
                aUser = new User();
            }
            return aUser;
        }
    }
}