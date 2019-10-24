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
    public class FeedCleanerHostedService: IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly ILogger _logger;
        private Timer _timer;

        public FeedCleanerHostedService(ILogger<FeedTimeHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cleaner Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(86400)); // clean up feeds once a day

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Cleaner Background Service is working.");

            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
                var expiredFeeds = dbContext.Feeds.Where(x => x.PublishedAt.Value.AddDays(7) < DateTime.Now || x.Link == null).ToList();
                // Remove all that are old feeds
                dbContext.Feeds.RemoveRange(expiredFeeds); 
                // Save
                dbContext.SaveChanges();
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cleaner Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
 
}
