using Microsoft.EntityFrameworkCore;
using YouTubeViewerDomain.Queries;
using YouTubeViewersDomain.Models;
using YouTubeViewersEntityFramework.DbContextFactory;
using YouTubeViewersEntityFramework.DTOs;
using YouTubeViewersEntityFramework.MyDbContext; 

namespace YouTubeViewersEntityFramework.Queries
{
    public class GetAllYouTubeViewersQuery : IGetAllYouTubeViewersQuery
    {
        private readonly YouTubeViewerDbContextFactory _contextFactory;

        public GetAllYouTubeViewersQuery(YouTubeViewerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<YouTubeViewer>> Execute()
        {
            using(YouTubeViewerDbContext context = _contextFactory.Create())
            {
                 IEnumerable<YouTubeViewerDto> youTubeViewerDtos = await context.YouTubeViewers.ToListAsync();
                 return youTubeViewerDtos.Select(y => 
                 new YouTubeViewer(
                     y.Id, 
                     y.Username, 
                     y.IsSubscribed, 
                     y.IsMember));
            }
        }
    }
}
