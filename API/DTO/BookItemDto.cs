using System.ComponentModel.DataAnnotations;

namespace API.DTO;

public record BookItemDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Id must be at least 1")]
    public int BookId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
}