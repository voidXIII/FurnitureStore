using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdAsync(int id);
        Task<IReadOnlyList<Room>> GetRoomsAsync();
        Task<IReadOnlyList<BookingStatus>> GetBookingStatusesAsync();
        Task<IReadOnlyList<RoomType>> GetRoomTypesAsync();
    }
}