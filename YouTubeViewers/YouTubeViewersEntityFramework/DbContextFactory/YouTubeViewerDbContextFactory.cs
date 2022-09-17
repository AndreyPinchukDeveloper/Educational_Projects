using Microsoft.EntityFrameworkCore;
using YouTubeViewersEntityFramework.MyDbContext;

namespace YouTubeViewersEntityFramework.DbContextFactory
{
    public class YouTubeViewerDbContextFactory
    {
        private readonly DbContextOptions _options;

        public YouTubeViewerDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public YouTubeViewerDbContext Create()
        {
            return new YouTubeViewerDbContext(_options);
        }
    }
}
