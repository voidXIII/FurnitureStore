using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Helpers;
using Domain.Entities;
using Application.Specifications;

namespace API.Services
{
    public interface IRoomService
    {
        Task<Pagination<RoomToReturnDto>> GetRoomsAsync(ParamsSpecification paramsSpec);
        Task<RoomToReturnDto> GetRoomWithSpecAsync(int id);
        Task<RoomToReturnDto> CreateRoomAsync(RoomToCreateDto roomToCreate);
        Task UpdateRoomAsync(int id, RoomToUpdateDto roomToUpdate);
        Task DeleteRoomAsync(int id);
        Task<IReadOnlyList<RoomType>> GetAllTypes();
    }
}