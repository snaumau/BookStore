namespace API.DTO;

public record OrderItemDto
{
    public int BookId { get; set; }

    public string BookName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}