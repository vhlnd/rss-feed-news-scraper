using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.Models
{
    public class Feed
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string UrlToImage { get; set; }

        public Source Source { get; set; }

        public int ReadCount { get; set; }

        public string UniqueLinkId { get; set; }
    }
}
