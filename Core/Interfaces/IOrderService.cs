using Core.Entities.OrderAggregate;
using Core.Specifications;

namespace Core.Interfaces;

public interface IOrderService
{
    Task<Order?> CreateOrderAsync(List<BookItem> orderItems);

    Task<Order?> GetOrderByIdAsync(int id);

    Task<IReadOnlyList<Order>?> GetAllOrdersAsync(OrderSpecificationParams orderParams);
}