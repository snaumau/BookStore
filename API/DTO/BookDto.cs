using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public record BookDto
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public decimal Price { get; set; }
    
    public DateTime ReleaseDate { get; set; }
}