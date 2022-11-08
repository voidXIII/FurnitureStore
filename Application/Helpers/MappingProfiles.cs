using AutoMapper;
using Application.Dtos;
using Domain.Entities;
using Application.Dtos.Basket;
using Domain.Entities.Identity;
using Application.Dtos.User;

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
            CreateMap<CustomerBasket, CustomerBasketToReturnDto>().ReverseMap();
            CreateMap<CustomerBasketCreateOrUpdateDTO, CustomerBasket>();
            CreateMap<BasketItem, CustomerBasketItemsToReturnDto>().ReverseMap();
        }
    }
}