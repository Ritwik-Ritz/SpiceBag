using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public class OrderAddRequestMapper :Profile
{
    public OrderAddRequestMapper()
    {
        CreateMap<OrdersAddRequest, Orders>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalBill, opt => opt.Ignore())
            .ForMember(dest => dest.OrderId, opt => opt.Ignore());
    }
}
