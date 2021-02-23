using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using AngularDotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AngularDotnetCore.Services
{
    public class AccountService
    {
        public AccountService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }
        private ApplicationContext appContext;
        public async Task<User> FindUser(User aUser) {
            return await appContext.Users.FirstOrDefaultAsync(user => user.Email == aUser.Email && user.Password == aUser.Password);
        }
    }
}