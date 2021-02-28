using System;

namespace AngularDotnetCore.Models
{
    public class ASPResponse
    {
        public String SessionId { get; set; }
        public User User { get; set; }
        public Item[] Items { get; set; }
        public Settings Settings { get; set; }
    }
}