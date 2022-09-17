using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewerDomain.Commands;
using YouTubeViewersDomain.Models;
using YouTubeViewersEntityFramework.DbContextFactory;
using YouTubeViewersEntityFramework.DTOs;
using YouTubeViewersEntityFramework.MyDbContext;

namespace YouTubeViewersEntityFramework.Commands
{
    public class CreateYouTubeViewerCommand:ICreateYouTubeViewerCommand
    {
        private readonly YouTubeViewerDbContextFactory _contextFactory;

        public CreateYouTubeViewerCommand(YouTubeViewerDbContextFactory contextFactory)
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

                context.YouTubeViewers.Add(youTubeViewerDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
