using Core.Entities.OrderAggregate;

namespace Core.Interfaces;

public interface IOrderService
{
    Task<Order?> CreateOrderAsync(List<BookItem> orderItems);

    Task<Order?> GetOrderByIdAsync();

    Task<IReadOnlyList<Order>?> GetOrdersAsync();
}