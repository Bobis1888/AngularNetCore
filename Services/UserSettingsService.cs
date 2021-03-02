using System;
using AngularNetCore.Models;

namespace AngularNetCore.Services
{
    //TODO real service
    public class UserSettingsService
    {
        //MOCK
        public Settings GetSettings(String email)
        {
            return new Settings
            {
                Email = "MOCK",
                Flows = new[]
                {
                    new Settings.Flow()
                    {
                        Name = "habr",
                        SubFlows = new[] {"all", "admin", "develop"}
                    }
                }
            };
        }
    }
}