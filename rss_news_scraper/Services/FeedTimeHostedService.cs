using rss_news_scraper.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rss_news_scraper.Services
{
    public class FeedTimeHostedService: IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly ILogger _logger;
        private Timer _timer;

        public FeedTimeHostedService(ILogger<FeedTimeHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Feed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(300)); // in five minutes, fetch new data

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Feed Background Service is working.");

            List<Feed> listFeeds = new List<Feed>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();

                // Load Sources
                var sources = dbContext.Sources.Where(x => x.IsOnline == true).ToList();

                foreach (var source in sources)
                {
                    RSSFeedReader.ReadFeed(source, listFeeds);
                }

                foreach (var feed in listFeeds)
                {
                    if (dbContext.Feeds.FirstOrDefault(x=> x.UniqueLinkId == feed.UniqueLinkId)!=null) {
                        continue;
                    }else
                    {
                      dbContext.Feeds.Add(feed);
                    }

                }

                dbContext.SaveChanges();
            }
  
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Feed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


    }
}
