using AutoMapper;
using Application.Dtos;
using Domain.Entities;

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
        }
    }
}