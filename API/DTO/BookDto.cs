using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public record BookDto
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }
    
    public DateTime ReleaseDate { get; set; }
}