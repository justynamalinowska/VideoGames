using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class GamePublisher
{
    [Key]
    public int Id { get; set; }
    public int GameId { get; set; }
    public int PublisherId  { get; set; }
    
    public virtual Game? Game { get; set; }
    public virtual Publisher? Publisher { get; set; }
}