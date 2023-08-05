namespace Core.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public Order()
    {
    }
    
    public Order(IReadOnlyList<OrderItem>? orderItems, decimal subtotal)
    {
        OrderItems = orderItems;
        Subtotal = subtotal;
    }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public IReadOnlyList<OrderItem>? OrderItems { get; set; }

    public decimal Subtotal { get; set; }
}