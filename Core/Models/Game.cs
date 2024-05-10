using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Game
{
    [Key]
    public int Id { get; set;}
    public int GenreId { get; set;}
    public string? GameName { get; set;}
    public virtual Genre? Genre { get; set; }
}