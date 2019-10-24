using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.Models
{
    public class Source
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsOnline { get; set; }

        public virtual ICollection<Feed> Feeds { get; set; }

    }
}
