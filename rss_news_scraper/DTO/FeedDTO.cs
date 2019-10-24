using rss_news_scraper.Helper;
using rss_news_scraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.DTO
{
    public class FeedDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string UrlToImage { get; set; }

        public SourceDTO Source { get; set; }

        public int ReadCount { get; set; }

        public string TimeAgo { get; set; }

        public FeedDTO(Feed feed)
        {
            Id = feed.Id;
            Title = feed.Title;
            Author = feed.Author;
            Link = feed.Link;
            Description = feed.Description;
            PublishedAt = feed.PublishedAt;
            UrlToImage = feed.UrlToImage;
            Source = new SourceDTO(feed.Source);
            ReadCount = feed.ReadCount;
            TimeAgo = RelativeDateParser.ConvertToTimeAgo(feed.PublishedAt.Value);
        }
    }
}
