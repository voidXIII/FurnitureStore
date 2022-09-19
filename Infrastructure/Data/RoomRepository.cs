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

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IReadOnlyList<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}