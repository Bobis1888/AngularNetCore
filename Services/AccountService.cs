using System.Threading.Tasks;
using AngularNetCore.Models;

namespace AngularNetCore.Services
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
            if (TestUser(aUser))
            {
                return aUser;
            }
            //MOCK
            return null;
            // return await appContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(aUser.Email) && user.Password.Equals(aUser.Password));
        }
        public async Task<User> CheckEmail(User aUser)
        {
            if (TestUser(aUser))
            {
                return aUser;
            }
            //MOCK
            return null;
            // return await appContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(aUser.Email));
        }
        public async Task<User> CreateUser(User aUser)
        {
            //MOCK
            if (TestUser(aUser))
            {
                aUser.Trusted = true;
            }
            // appContext.Users.Add(new User()
            // {
            //     Password = aUser.Password,
            //     Email = aUser.Email,
            //     Trusted = true
            // });
            // aUser.Trusted = true;
            // await appContext.SaveChangesAsync();
            return aUser;
            
        }
        private bool TestUser(User aUser)
        {
            return (aUser.Email.Equals("test@test") && aUser.Password.Equals("test"));
        }
    }
}