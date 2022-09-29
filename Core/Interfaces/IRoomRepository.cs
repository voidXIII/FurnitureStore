using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdAsync(int id);
        Task<IReadOnlyList<Room>> GetRoomsAsync();
        Task<IReadOnlyList<BookingStatus>> GetBookingStatusesAsync();
        Task<IReadOnlyList<RoomType>> GetRoomTypesAsync();
    }
}