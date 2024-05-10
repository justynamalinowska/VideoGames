using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class RegionSales
{
    [Key]
    public int RegionId { get; set; }
    public int GamePlatformId { get; set; }
    public int NumSales { get; set; }
    
    public virtual Region? Region { get; set; }
    public virtual GamePlatform? GamePlatform { get; set; }
}