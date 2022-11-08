using AutoMapper;
using Application.Dtos;
using Domain.Entities;
using Application.Dtos.Basket;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Topology, o => o.MapFrom(s => s.Topology.TopologyTitle))
                .ForMember(d => d.Function, o => o.MapFrom(s => s.Function.FunctionTitle));
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<ProductToUpdateDto, Product>();
            CreateMap<Topology, ProductTopologyToReturnDto>();
            CreateMap<Function, ProductFunctionToReturnDto>();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketToReturnDto>().ReverseMap();
            CreateMap<CustomerBasketCreateOrUpdateDTO, CustomerBasket>();
            CreateMap<BasketItem, CustomerBasketItemsToReturnDto>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryType, o => o.MapFrom(s => s.DeliveryType.Title))
                .ForMember(d => d.DeliveryPrice, o => o.MapFrom(s => s.DeliveryType.Price));
            CreateMap<OrderedProduct, OrderedProductDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductOrdered.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ProductOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ProductOrdered.ImageUrl));
        }
    }
}