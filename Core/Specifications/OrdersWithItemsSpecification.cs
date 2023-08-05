using Core.Entities.OrderAggregate;

namespace Core.Specifications;

/// <summary>
/// Order specification with params
/// </summary>
public class OrdersWithItemsSpecification : BaseSpecification<Order>
{
    /// <summary>
    /// Get entity by id and include order items
    /// </summary>
    /// <param name="id"></param>
    public OrdersWithItemsSpecification(int id) : base(o => o.Id == id)
    {
        AddInclude(o => o.OrderItems!);
    }

    /// <summary>
    /// Expression with different params for filtered query
    /// </summary>
    /// <param name="orderParams"></param>
    public OrdersWithItemsSpecification(OrderSpecificationParams orderParams) : base(x => orderParams.Id == null || x.Id == orderParams.Id)
    {
        AddInclude(o => o.OrderItems!);
        
        if (orderParams.Date.HasValue)
            AddFindByReleaseDate(x => x.OrderDate.Date == orderParams.Date.Value);
    }
}