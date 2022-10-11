using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Core.Specifications;

namespace API.Services
{
    public interface IRoomService
    {
        Task<Pagination<RoomToReturnDto>> GetRoomsAsync(ParamsSpecification paramsSpec);
        Task<RoomToReturnDto> GetRoomWithSpecAsync(int id);
        Task<RoomToReturnDto> CreateRoomAsync(RoomToCreateDto roomToCreate);
        Task UpdateRoomAsync(int id, RoomToUpdateDto roomToUpdate);
        Task DeleteRoomAsync(int id);
    }
}