using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Login(User aUser)
        {
            if (ModelState.IsValid)
            {
                var user = accountService.FindUser(aUser).Result;
                
                if (user != null)
                {
                    Task task = Authenticate(aUser.Email);
                    task.Wait();
                    return Ok(user);
                }
                ModelState.AddModelError("user","not.found");
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        private async Task Authenticate(string email)
        {
            var claims = new List<Claim>{
                new Claim(ClaimsIdentity.DefaultNameClaimType,email)
            };
            var id = new ClaimsIdentity(claims,"ApplicationCookie",ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}