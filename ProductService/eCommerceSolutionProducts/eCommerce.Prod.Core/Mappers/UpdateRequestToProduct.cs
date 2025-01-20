using AutoMapper;
using eCommerce.Prod.Core.DTO;
using eCommerce.Prod.Service.Entities;


namespace eCommerce.Prod.Core.Mappers
{
    public class UpdateRequestToProduct : Profile
    {
        public UpdateRequestToProduct()
        {
            CreateMap<ProductUpdateRequest, Product>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }

    }
}
