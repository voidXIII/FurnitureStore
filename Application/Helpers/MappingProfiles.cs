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
            CreateMap<Room, RoomToReturnDto>()
                .ForMember(d => d.BookingStatus, o => o.MapFrom(s => s.BookingStatus.BookingStatusTitle))
                .ForMember(d => d.RoomType, o => o.MapFrom(s => s.RoomType.RoomTypeName));
            CreateMap<RoomToCreateDto, Room>();
            CreateMap<RoomToUpdateDto, Room>();
            CreateMap<RoomType, RoomTypeToReturnDto>();
            CreateMap<CustomerBasket, CustomerBasketToReturnDto>().ReverseMap();
            CreateMap<CustomerBasketCreateOrUpdateDTO, CustomerBasket>();
            CreateMap<BasketItem, CustomerBasketItemsToReturnDto>().ReverseMap();
        }
    }
}