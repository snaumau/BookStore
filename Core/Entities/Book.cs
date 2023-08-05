namespace Core.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }
}