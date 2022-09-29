using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Room, RoomToReturnDto>()
                .ForMember(d => d.BookingStatus, o => o.MapFrom(s => s.BookingStatus.BookingStatusTitle))
                .ForMember(d => d.RoomType, o => o.MapFrom(s => s.RoomType.RoomTypeName))
                .ForMember(d => d.RoomMainImageUrl, o => o.MapFrom<RoomUrlResolver>());
        }
    }
}