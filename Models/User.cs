using System.Collections.Generic;

namespace AngularNetCore.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Password { get; set; } = "******";
        public bool Trusted {get; set;} = false;
        public Settings Settings { get; set; } 
    }
}