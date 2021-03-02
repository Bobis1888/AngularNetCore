using System.Collections.Generic;
using System.Linq;
using AngularNetCore.Models;
using HtmlAgilityPack;

namespace AngularNetCore.Services
{
    public class ItemService
    {
        private static List<Item> habrItems;
        private IEnumerable<Item> currentItems;
        private HttpClientService clientService;
        private RssService rssService;
        public ItemService(HttpClientService clientService,RssService rssService)
        {
            this.clientService = clientService;
            this.rssService = rssService;
        }
        private string DeterminingUrl(string nameSource,string flow)
        {
            var url = "";
            if(nameSource.Equals("habr"))
            {
                //MOCK
                //TODO determining flows
                switch (flow)
                {
                    case "all" : flow = "all/all";
                        break;
                    case "develop" : flow = "develop/all";
                        break;
                    case "admin" : flow = "admin/all";
                        break;
                    case "best" : flow = "best/weekly";
                        break;
                    case "develop&top" : flow = "develop/top/weekly";
                        break;
                    case "admin&top" : flow = "admin/top/weekly";
                        break;
                }
                url = $"https://habr.com/ru/rss/{flow}/?fl=ru%2Cen";
            }
            return url;
        }
        public IEnumerable<Item> GetItems(string nameSource,string flow)
        {
            var url = DeterminingUrl(nameSource,flow);
            var posts = rssService.GetPostsFromRss(url);
            habrItems = new List<Item>();
            foreach (var post in posts)
            {
                habrItems.Add(new Item()
                {
                    Header = post.Title.Text,
                    Body = post.Summary.Text.Replace("<img","<div").Replace("<a","<span"),//hide image and links on preview,
                    PublishDate = post.PublishDate,
                    Url = post.Id
                    
                });
            }
            return habrItems;
        }
        public Item GetItem(string nameSource,string flow ,string postId)
        {
            //TODO rewrite not only habr
            if(nameSource.Contains("habr"))
            {
                currentItems = habrItems;
            }
            else
            {
                return new Item(){
                    Header = $"Sorry, this post was not found or something went wrong.\nPost url : {postId}"
                };
            }
            var item = currentItems.FirstOrDefault(i => i.PostId.Equals(postId));
            var postHtml = clientService.GetPageFromWeb(item.Url).Result;
            item.Body = GetBodyPost(postHtml);
            return item;
        }
        //TODO write a handler html
        private string GetBodyPost(string postHtml)
        {
            var page = new HtmlDocument();
            page.LoadHtml(postHtml);
            var postBody = page.DocumentNode.SelectSingleNode("//div[@id=\"post-content-body\"]");
            foreach (var node in postBody.SelectNodes("//img"))
            {
                //Repair image size
                var attr = node.Attributes;
                attr.Remove("width");
                attr.Remove("height");
                attr.Add("width","100%");
                attr.Add("height","100%");
            }
            return postBody.InnerHtml;
        }
    }
}
