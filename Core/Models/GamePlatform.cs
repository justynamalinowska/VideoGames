using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class GamePlatform
{
    [Key]
    public int Id { get; set;}
    public int GamePublisherId { get; set;}
    public int PlatformId { get; set;}
    public int ReleaseYear { get; set;}
    
    public virtual GamePublisher? GamePublisher { get; set; }
    public virtual Platform? Platform { get; set; }
}