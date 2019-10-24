using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rss_news_scraper.DTO;
using rss_news_scraper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rss_news_scraper.Controllers
{
    [Route("api/[controller]")]
    public class FeedController : Controller
    {
        private DBContext db;

        public FeedController(DBContext _db)
        {
            db = _db;
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Feed> Get()
        {
            return db.Feeds.ToList();
        }

        [HttpGet]
        [Route("paged")]
        public PagedFeedDTO GetPaged(int? page = 1, int? pageSize = 10)
        {
            if(!page.HasValue)
            {
                return new PagedFeedDTO(db.Feeds.ToList(), 0, 0, 0);
            }

            // do some pagination

            var query = db.Feeds.Include(x=> x.Source).OrderByDescending(x => x.PublishedAt.Value);
            var feeds = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
            var count = feeds.Count();
            // 
            return new PagedFeedDTO(feeds, page.Value, count, pageSize.Value);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Feed Get(Guid id)
        {
            return db.Feeds.Include(x => x.Source).FirstOrDefault( x => x.Id == id );
        }

    }
}
