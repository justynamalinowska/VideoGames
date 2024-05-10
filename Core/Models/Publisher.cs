using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }
    public string? PublisherName { get; set; }
}