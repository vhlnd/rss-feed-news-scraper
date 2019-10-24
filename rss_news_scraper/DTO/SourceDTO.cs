using rss_news_scraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.DTO
{
    public class SourceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public SourceDTO(Source source)
        {
            Id = source.Id;
            Name = source.Name;
            Link = source.Link;
        }

    }
}
