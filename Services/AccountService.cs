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
        public async Task<User> FindUser(User aUser) 
        {
            return await appContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(aUser.Email) && user.Password.Equals(aUser.Password));
        }
        public async Task<User> CheckEmail(User aUser)
        {
            return await appContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(aUser.Email));
        }
        public async Task<User> CreateUser(User aUser) 
        {
            appContext.Users.Add(new User()
            {
                Password = aUser.Password,
                Email = aUser.Email,
                Trusted = true
            });
            aUser.Trusted = true;
            await appContext.SaveChangesAsync();
            return aUser;
        }
    }
}