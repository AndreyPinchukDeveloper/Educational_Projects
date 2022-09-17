using YouTubeViewerDomain.Commands;
using YouTubeViewersDomain.Models;
using YouTubeViewersEntityFramework.DbContextFactory;
using YouTubeViewersEntityFramework.DTOs;
using YouTubeViewersEntityFramework.MyDbContext;

namespace YouTubeViewersEntityFramework.Commands
{
    public class UpdateYouTubeViewerCommand : IUpdateYouTubeViewerCommand
    {
        private readonly YouTubeViewerDbContextFactory _contextFactory;

        public UpdateYouTubeViewerCommand(YouTubeViewerDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(YouTubeViewer youTubeViewer)
        {
            using (YouTubeViewerDbContext context = _contextFactory.Create())
            {
                YouTubeViewerDto youTubeViewerDto = new YouTubeViewerDto()
                {
                    Id = youTubeViewer.Id,
                    Username = youTubeViewer.Username,
                    IsSubscribed = youTubeViewer.IsSubscribed,
                    IsMember = youTubeViewer.IsMember
                };

                context.YouTubeViewers.Update(youTubeViewerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
