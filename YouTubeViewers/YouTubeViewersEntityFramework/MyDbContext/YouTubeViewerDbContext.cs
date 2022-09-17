using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewersDomain.Models;
using YouTubeViewersEntityFramework.DTOs;

namespace YouTubeViewersEntityFramework.MyDbContext
{
    public class YouTubeViewerDbContext:DbContext
    {
        public YouTubeViewerDbContext(DbContextOptions options):base(options) { }
        public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }
    }
}
