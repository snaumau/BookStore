namespace Core.Specifications;

/// <summary>
/// Book specification for query
/// </summary>
public class BookSpecificationParams
{
    private string _search = string.Empty;
    
    public string Search
    {
        get => _search;
        set => _search = value.ToLowerInvariant();
    }
    
    public string Sort { get; set; } = string.Empty;

    public DateTime? Date { get; set; }
}