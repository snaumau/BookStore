namespace API.DTO;

public record OrderDto
{
    public int Id { get; set; }
    
    public DateTime OrderDate { get; set; }

    public IReadOnlyList<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    public decimal Subtotal { get; set; }
}