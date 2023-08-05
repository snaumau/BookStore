using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services;

/// <summary>
/// Order service
/// </summary>
public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<Book> _bookRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="orderRepository"></param>
    /// <param name="bookRepository"></param>
    public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<Book> bookRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
    }
    
    public Task<Order?> CreateOrderAsync(List<BookItem> orderItems)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetOrderByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>?> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }
}