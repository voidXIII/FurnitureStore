using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;
        public RoomRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<BookingStatus>> GetBookingStatusesAsync()
        {
            return await _context.BookingStatuses.ToListAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms
                .Include(p => p.BookingStatus)
                .Include(p => p.RoomType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Room>> GetRoomsAsync()
        {
            return await _context.Rooms
                .Include(p => p.BookingStatus)
                .Include(p => p.RoomType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<RoomType>> GetRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }
    }
}