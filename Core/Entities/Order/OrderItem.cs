namespace Core.Entities.Order;

public class OrderItem : BaseEntity
{
    public OrderItem()
    {
    }
    
    public OrderItem(BookItem? bookItem, decimal price, int quantity)
    {
        BookItem = bookItem;
        Price = price;
        Quantity = quantity;
    }

    public BookItem? BookItem { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}