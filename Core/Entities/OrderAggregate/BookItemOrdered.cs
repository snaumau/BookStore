namespace Core.Entities.OrderAggregate;

public class BookItemOrdered
{
    public BookItemOrdered()
    {
    }
    
    public BookItemOrdered(int bookItemId, string bookName)
    {
        BookItemId = bookItemId;
        BookName = bookName;
    }
    
    public int BookItemId { get; set; }

    public string BookName { get; set; } = string.Empty;
}