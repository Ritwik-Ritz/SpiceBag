using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public class OrderItemResponseMapper:Profile
{
    public OrderItemResponseMapper()
    {
        CreateMap<OrderItem, OrderItemResponse>()
        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src=>src.TotalPrice));
    }
}
