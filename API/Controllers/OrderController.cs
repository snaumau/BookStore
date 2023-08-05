using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Order controller
/// </summary>
public class OrderController : BaseApiController
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="orderService"></param>
    /// <param name="mapper"></param>
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    /// <summary>
    /// Get order by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return the order</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order is null)
            return NotFound(new ApiResponse(404));

        var data = _mapper.Map<OrderDto>(order);

        return data;
    }

    /// <summary>
    /// Get list of the orders
    /// </summary>
    /// <param name="orderParams"></param>
    /// <returns>Return the list of the orders</returns>
    [HttpGet("getFilteredOrders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrders([FromQuery] OrderSpecificationParams orderParams)
    {
        var orders = await _orderService.GetAllOrdersAsync(orderParams);
        var data = _mapper.Map<IReadOnlyList<OrderDto>>(orders);

        return Ok(data);
    }

    /// <summary>
    /// Create order
    /// </summary>
    /// <param name="bookItems"></param>
    /// <returns>Return created order</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderDto>> CreateOrder(List<BookItemDto> bookItems)
    {
        var items = _mapper.Map<List<BookItem>>(bookItems);
        var order = await _orderService.CreateOrderAsync(items);
        if (order is null)
            return BadRequest(new ApiResponse(400));

        var data = _mapper.Map<OrderDto>(order);

        return Ok(data);
    }
}