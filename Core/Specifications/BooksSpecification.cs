using Core.Entities;

namespace Core.Specifications;

/// <summary>
/// Book specifications by params
/// </summary>
public class BooksSpecification : BaseSpecification<Book>
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bookParams"></param>
    public BooksSpecification(BookSpecificationParams bookParams) : base(x =>
        string.IsNullOrEmpty(bookParams.Search) ||
        x.Name.ToLower().Contains(bookParams.Search))

    {
        AddOrderBy(x => x.Id);

        if (!string.IsNullOrEmpty(bookParams.Sort))
        {
            switch (bookParams.Sort)
            {
                case "nameAsc":
                    AddOrderBy(p => p.Name);
                    break;
                case "nameDesc":
                    AddOrderByDescending(p => p.Name);
                    break;
                case "releaseAsc":
                    AddOrderBy(p => p.ReleaseDate);
                    break;
                case "releaseDesc":
                    AddOrderByDescending(p => p.ReleaseDate);
                    break;
                default:
                    AddOrderBy(n => n.Id);
                    break;
            }
        }

        if (bookParams.Date.HasValue)
            AddFindByReleaseDate(x => x.ReleaseDate == bookParams.Date.Value);
    }
}