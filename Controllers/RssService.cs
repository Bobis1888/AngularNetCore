using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using AngularDotnetCore.Models;
using HtmlAgilityPack;

namespace AngularDotnetCore.Controllers
{
    public class RssService
    {
        private static List<Item> Items;
        private static HttpClient Client = new HttpClient();


        public static IEnumerable<Item> GetItemsFromRss(string nameSource)
        {
            Items = new List<Item>();
            string url = "";
            if(nameSource.Equals("habr"))
            {
                //TODO rewrite
                url = "https://habr.com/ru/rss/flows/develop/all/?fl=ru%2Cen";
            }
            using var reader = System.Xml.XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            //TODO rewrite
            //TODO delete habr link
            foreach (var post in feed.Items)
            {
                Items.Add(new Item()
                {
                    Header = post.Title.Text,
                    Body = post.Summary.Text.Replace("img","ac").Replace("a","ac"),//hide image on preview,
                    PublishDate = post.PublishDate,
                    Url = post.Id
                    
                });
            }
            return Items;
        }

        public static Item GetItemBody(string postId)     
        {
            var item = Items.Where(i => i.PostId.Equals(postId)).FirstOrDefault();
            var page = new HtmlDocument();
            page.LoadHtml(GetBody(item.Url).Result);
            var postBody = page.DocumentNode.SelectSingleNode("//div[@id=\"post-content-body\"]");
            item.Body = postBody.InnerHtml;
            return item;
        }

        private static async Task<string> GetBody(string postId)
        {
            var res = "";
            try
            {
                res = await Client.GetStringAsync(postId);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            return res;
        }

    }
}