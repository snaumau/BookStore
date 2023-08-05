namespace Core.Entities.Order;

public class BookItem
{
    public BookItem(int bookItemId, string bookName)
    {
        BookItemId = bookItemId;
        BookName = bookName;
    }
    
    public int BookItemId { get; set; }

    public string BookName { get; set; }
}