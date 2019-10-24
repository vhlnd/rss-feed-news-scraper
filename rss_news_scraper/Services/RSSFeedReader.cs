using rss_news_scraper.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml;

namespace rss_news_scraper.Services
{
    public static class RSSFeedReader
    {
        public static void ReadFeed(Source source, List<Feed> listFeeds)
        {
            try
            {
                XmlReader reader = XmlReader.Create(source.Link);

                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                foreach (SyndicationItem item in feed.Items)
                {

                    listFeeds.Add(new Feed
                    {
                        Id = Guid.NewGuid(),
                        Title = item.Title.Text,
                        Author = (item.Authors.Count > 0) ? item.Authors[0].Name : null,
                        Description = item.Summary.Text,
                        PublishedAt = item.PublishDate.DateTime,
                        Link = item.Id.ToString(),
                        UrlToImage = (item.Links.Count > 1) ? item.Links[1].Uri.OriginalString : TryDecodeLink(item.Summary.Text),
                        Source = source,
                        UniqueLinkId = item.Id.ToString()
                    });
              
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static string TryDecodeLink(string description)
        {
            string imageSource = null;
            try
            {
                var regex = Regex.Match(description, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
            
                if (regex.Success)
                {
                    if (regex.Groups.Count > 0) { imageSource = regex.Groups[1].Value; } else { imageSource = null; }
                }
            }
            catch (Exception)
            {
                imageSource = null;
            }
           
            return imageSource; 
        }
    }
}
