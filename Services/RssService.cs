using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace AngularNetCore.Services
{
    public class RssService
    {
        public IEnumerable<SyndicationItem> GetPostsFromRss(string url)
        {
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            return feed.Items;
        }
    }
}