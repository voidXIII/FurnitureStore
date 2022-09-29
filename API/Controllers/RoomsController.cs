using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IGenericRepository<BookingStatus> _bookingStatusRepo;
        private readonly IGenericRepository<RoomType> _roomTypeRepo;
        public RoomsController(IGenericRepository<Room> roomRepo, IGenericRepository<BookingStatus> bookingStatusRepo,
                            IGenericRepository<RoomType> roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
            _bookingStatusRepo = bookingStatusRepo;
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            var rooms = await _roomRepo.ListAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            return await _roomRepo.GetByIdAsync(id);
        }

        [HttpGet("bookingstatuses")]
        public async Task<ActionResult<IReadOnlyList<BookingStatus>>> GetBookingStatuses()
        {
            return Ok(await _bookingStatusRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<RoomType>>> GetRoomTypes()
        {
            return Ok(await _roomTypeRepo.ListAllAsync());
        }
    }
}