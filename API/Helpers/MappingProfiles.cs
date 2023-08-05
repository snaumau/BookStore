using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Helpers;

/// <summary>
/// Mapping profiles for entities
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Mapping profile for book
        CreateMap<Book, BookDto>()
            .ReverseMap();

        // Mapping profile for order
        CreateMap<Order, OrderDto>()
            .ReverseMap();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.ItemOrdered!.BookItemId))
            .ForMember(d => d.BookName, opt => opt.MapFrom(s => s.ItemOrdered!.BookName))
            .ReverseMap();
        CreateMap<BookItem, BookItemDto>()
            .ReverseMap();
    }
}