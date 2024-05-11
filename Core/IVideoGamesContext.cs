using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core;

public interface IVideoGamesContext
{
    DbSet<Game> Games { get; set; }
    DbSet<GamePlatform> GamePlatforms { get; set; }
    DbSet<GamePublisher> GamePublishers { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Platform> Platforms { get; set; }
    DbSet<Publisher> Publishers { get; set; }
    DbSet<Region> Regions { get; set; }
    DbSet<RegionSale> RegionSales { get; set; }
}