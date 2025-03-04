﻿using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public class OrderItemUpdateRequestMapper:Profile
{
    public OrderItemUpdateRequestMapper()
    {
        CreateMap<OrderItemUpdateRequest, OrderItem>()
        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());
    }
}
