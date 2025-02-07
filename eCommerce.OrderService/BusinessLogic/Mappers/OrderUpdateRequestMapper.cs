﻿
using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;
namespace BusinessLogic.Mappers;

public class OrderUpdateRequestMapper:Profile
{
    public OrderUpdateRequestMapper()
    {
        CreateMap<OrdersUpdateRequest, Orders>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.TotalBill, opt => opt.Ignore());
    }

}
