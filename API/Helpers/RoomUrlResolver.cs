using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class RoomUrlResolver : IValueResolver<Room, RoomToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public RoomUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Room source, RoomToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.RoomMainImageUrl))
            {
                return _config["ApiUrl"] + source.RoomMainImageUrl;
            }
            return null;
        }
    }
}