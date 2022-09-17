using YouTubeViewerDomain.Commands;
using YouTubeViewersDomain.Models;
using YouTubeViewersEntityFramework.DbContextFactory;
using YouTubeViewersEntityFramework.DTOs;
using YouTubeViewersEntityFramework.MyDbContext;

namespace YouTubeViewersEntityFramework.Commands
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewerDbContextFactory _contextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (YouTubeViewerDbContext context = _contextFactory.Create())
            {
                YouTubeViewerDto youTubeViewerDto = new YouTubeViewerDto()
                {
                    Id = id
                };

                context.YouTubeViewers.Remove(youTubeViewerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
