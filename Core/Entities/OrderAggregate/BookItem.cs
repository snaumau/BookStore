namespace Core.Entities.OrderAggregate;

public abstract class BookItem : BaseEntity
{
    public int Quantity { get; set; }
}