namespace Core.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public OrderItem()
    {
    }
    
    public OrderItem(BookItemOrdered itemOrderedItemOrdered, decimal price, int quantity)
    {
        ItemOrdered = itemOrderedItemOrdered;
        Price = price;
        Quantity = quantity;
    }
    
    public BookItemOrdered? ItemOrdered { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}