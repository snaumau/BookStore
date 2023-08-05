using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Book : BaseEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; } = DateTime.Now;
}