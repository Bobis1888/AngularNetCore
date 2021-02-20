using System;
namespace AngularDotnetCore.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Url {get; set;}
        public string Body {get; set;}
        public string Header {get; set;}
        public DateTimeOffset PublishDate {get; set;}
        public string PostId
        {
            get
            { 
                return Url.Split("post")[1].Replace("/","");
            }
        }

    }
}