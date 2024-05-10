using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core;

public interface IVideoGameContext
{
    DbSet<Game> Games { get; set; }
    DbSet<GamePlatform> GamesPlatforms { get; set; }
    DbSet<GamePublisher> GamePublishers { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Platform> Platforms { get; set; }
    DbSet<Publisher> Publishers { get; set; }
    DbSet<Region> Regions { get; set; }
    DbSet<RegionSales> RegionSales { get; set; }
}