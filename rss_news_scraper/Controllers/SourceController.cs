using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rss_news_scraper.Models;
using Microsoft.AspNetCore.Mvc;

namespace rss_news_scraper.Controllers
{
    [Route("api/[controller]")]
    public class SourceController : Controller
    {
        private DBContext db;

        public SourceController(DBContext _db)
        {
            db = _db;
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Source> Get()
        {
            return db.Sources.ToList();
        }

    }
}
