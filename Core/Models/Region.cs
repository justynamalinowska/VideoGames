using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Region
{
    [Key]
    public int Id { get; set; }
    public string? RegionName { get; set; }
}