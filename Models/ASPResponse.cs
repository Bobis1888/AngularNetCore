using System;

namespace AngularNetCore.Models
{
    public class ASPResponse
    {
        public String SessionId { get; set; }
        public User User { get; set; }
        public Item[] Items { get; set; }
        public Settings Settings { get; set; }
    }
}