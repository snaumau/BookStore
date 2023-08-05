using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services;

/// <summary>
/// Order service
/// </summary>
public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="unitOfWork"></param>
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Order?> CreateOrderAsync(List<BookItem> orderItems)
    {
        var items = new List<OrderItem>();
        foreach (var item in orderItems)
        {
            var bookItem = await _unitOfWork.Repository<Book>().GetByIdAsync(item.BookId);
            if (bookItem is null)
                return null;
            var itemOrdered = new BookItemOrdered(bookItem.Id, bookItem.Name);
            var orderItem = new OrderItem(itemOrdered, bookItem.Price, item.Quantity);
            items.Add(orderItem);
        }
        
        var subtotal = items.Sum(item => item.Price * item.Quantity);
        
        var order = new Order(items, subtotal);
        _unitOfWork.Repository<Order>().Add(order);
        
        var result = await _unitOfWork.Complete();
        if (result <= 0)
            return null;
        
        return order;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        var specification = new OrdersWithItemsSpecification(id);

        return await _unitOfWork.Repository<Order>().GetEntityWithSpec(specification);
    }

    public async Task<IReadOnlyList<Order>?> GetAllOrdersAsync(OrderSpecificationParams orderParams)
    {
        var specification = new OrdersWithItemsSpecification(orderParams);
        
        return await _unitOfWork.Repository<Order>().ListAllAsync(specification);
    }
}