using Core.Entities.OrderAggregate;

namespace Core.Specifications;

public class OrdersWithItemsSpecification : BaseSpecification<Order>
{
    public OrdersWithItemsSpecification(int id) : base(o => o.Id == id)
    {
        AddInclude(o => o.OrderItems!);
    }

    public OrdersWithItemsSpecification(OrderSpecificationParams orderParams) : base(x => orderParams.Id == null || x.Id == orderParams.Id)
    {
        AddInclude(o => o.OrderItems!);
        
        if (orderParams.Date.HasValue)
            AddFindByReleaseDate(x => x.OrderDate.Date == orderParams.Date.Value);
    }
}