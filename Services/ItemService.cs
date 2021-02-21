using System.Collections.Generic;
using System.Linq;
using AngularDotnetCore.Models;
using HtmlAgilityPack;

namespace AngularDotnetCore.Services
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
        private string determiningUrl(string nameSource,string flow)
        {
            var url = "";
            if(nameSource.Equals("habr"))
            {
                //TODO check flow
                if(flow.Equals("all") || flow == null)
                {
                    flow = "best/daily";
                }
                url = $"https://habr.com/en/rss/{flow}/?fl=ru%2Cen";
            }
            return url;
        }
        public IEnumerable<Item> GetItems(string nameSource,string flow)
        {
            var url = determiningUrl(nameSource,flow);
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
                    Header = $"Sorry, this post was not found or something went wrong.\nServer say => post url : {postId}"
                };
            }
            var item = currentItems.Where(i => i.PostId.Equals(postId)).FirstOrDefault();
            var postHtml = clientService.GetPageFromWeb(item.Url).Result;
            item.Body = getBodyPost(postHtml);
            return item;
        }
        //TODO write a handler html
        private string getBodyPost(string postHtml)
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