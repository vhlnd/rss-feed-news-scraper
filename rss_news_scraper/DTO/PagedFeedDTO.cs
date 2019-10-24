using rss_news_scraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.DTO
{
    public class PagedFeedDTO
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public FeedDTO[] Items { get; set; }

        public PagedFeedDTO(ICollection<Feed> feeds, int page, int numberOfItems, int pageSize)
        {
            PageSize = pageSize;
            Items = feeds.Select(feed => new FeedDTO(feed) ).OrderBy(x=> x.PublishedAt).ToArray();
            Count = numberOfItems;
            Page = page;
        }
    }
}
