using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AngularDotnetCore.Models;
using AngularDotnetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AngularDotnetCore.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        // TODO [ValidateAntiForgeryToken]
        public IActionResult Login(User aUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            aUser = Authenticate(aUser).Result;
            CacheUser(aUser);
            return Ok(new ASPResponse{User = aUser});
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("registration")]
        // TODO [ValidateAntiForgeryToken]
        public IActionResult Registration(User aUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            aUser = CreateUser(aUser).Result;
            aUser = Authenticate(aUser).Result;
            CacheUser(aUser);
            return Ok(new ASPResponse{User = aUser});
        }

        [HttpGet("check")]
        [AllowAnonymous]
        public IActionResult Check()
        {
            return Ok(new ASPResponse{User = CheckUserInCache()});
        }

        [HttpPost]
        [Route("info")]
        [Authorize]
        public IActionResult AccountInfo(User user)
        {
            return Ok(new ASPResponse{Settings = GetSettings(user.Email)});
        }
        [HttpGet("nonauth")]
        public IActionResult NonAuth()
        {
            return Ok(new ASPResponse{User = new User()});
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            Exit().Wait();
            return Ok(new ASPResponse{User = new User()});
        }

        private async Task<User> Authenticate(User aUser)
        {
            if(accountService.FindUser(aUser).Result != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimsIdentity.DefaultNameClaimType,aUser.Email)
                };
                var id = new ClaimsIdentity(claims,"ApplicationCookie",ClaimsIdentity.DefaultNameClaimType,ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                aUser.Trusted = true;
                aUser.Password = "******";
            }
            else
            {
                aUser = new User();
            }
            return aUser;
        }
        private async Task<User> CreateUser(User aUser)
        {
            if(accountService.CheckEmail(aUser).Result == null)
            {
                aUser = await accountService.CreateUser(aUser);
                aUser.Password = "******";
                aUser.Trusted = true;
            }
            else
            {
                aUser = new User();
            }
            return aUser;
        }
        private async Task Exit()
        {
            ClearCacheUser();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        // TODO user settings
        private Settings GetSettings(string email)
        {
            var uSettings = new UserSettingsService();
            return uSettings.GetSettings(email);
        }
        private void CacheUser(User aUser)
        {
            HttpContext.Session.SetString("email",aUser.Email);
            HttpContext.Session.SetString("trusted",true.ToString());
        }

        private void ClearCacheUser()
        {
            HttpContext.Session.Clear();
        }

        private User CheckUserInCache()
        {
            var user = new User();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                user.Email = HttpContext.Session.GetString("email");
                user.Trusted = bool.Parse(HttpContext.Session.GetString("trusted"));
            }
            return user;
        }
    }
}