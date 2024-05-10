using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    public string? PlatformName { get; set; }
}