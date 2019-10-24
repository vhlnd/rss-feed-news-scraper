using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_news_scraper.Models
{
    public class DBContext: DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Source> Sources { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region "Seed Data"

            modelBuilder.Entity<Source>().HasData(

                new Source
                {
                    Id = 1,
                    Name = "Cointelegraph",
                    Link = "https://cointelegraph.com/rss",
                    IsOnline = true,
                },
               new Source
               {
                   Id = 2,
                   Name = "Cryptocurrencynews",
                   Link = "https://cryptocurrencynews.com/feed/",
                   IsOnline = false,
               },
                new Source
                {
                    Id = 3,
                    Name = "Coindesk",
                    Link = "https://www.coindesk.com/feed/",
                    IsOnline = true,
                },
                new Source
                {
                    Id = 4,
                    Name = "CoinJournal",
                    Link = "https://coinjournal.net/feed/",
                    IsOnline = true
                },
                new Source
                {
                    Id = 5,
                    Name = "News-Bitcoin",
                    Link = "https://news.bitcoin.com/feed/",
                    IsOnline = true
                },
                new Source
                {
                    Id = 6,
                    Name = "Cryptoninjas",
                    Link = "https://www.cryptoninjas.net/feed/",
                    IsOnline = true
                },
                 new Source
                 {
                     Id = 7,
                     Name = "Etheriumworldnews",
                     Link = "https://ethereumworldnews.com/feed/",
                     IsOnline = true
                 },
                 new Source
                 {
                     Id = 8,
                     Name = "FinanceMagnates",
                     Link = "https://www.financemagnates.com/feed/",
                     IsOnline = true
                 },
                 new Source
                 {
                     Id = 9,
                     Name = "CryptoNewsMonitor",
                     Link = "https://cryptonewsmonitor.com/feed/",
                     IsOnline = true
                 },
                 new Source
                 {
                     Id = 10,
                     Name = "Bitcoinist",
                     Link = "http://bitcoinist.com/feed/",
                     IsOnline = true
                 },
                 new Source
                 {
                     Id = 11,
                     Name = "Changelly",
                     Link = "https://changelly.com/blog/feed/",
                     IsOnline = true
                 },
                 new Source
                 {
                     Id = 12,
                     Name = "NewsBTC",
                     Link = "https://www.newsbtc.com/feed/",
                     IsOnline = true
                 }

                );
  
            #endregion
        }
    }
}
