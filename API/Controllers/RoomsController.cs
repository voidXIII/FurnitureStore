using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        public async Task<ActionResult<List<RoomToReturnDto>>> GetRooms()
        {
            var spec = new RoomsWithTypesAndBookingStatusesSpecification();
            var rooms = await _roomRepo.ListAsync(spec);
            return rooms.Select(room => new RoomToReturnDto 
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                RoomName = room.RoomName,
                RoomMainImageUrl = room.RoomMainImageUrl,
                RoomPrice = room.RoomPrice,
                BookingStatus = room.BookingStatus.BookingStatusTitle,
                RoomType = room.RoomType.RoomTypeName,
                RoomCapacity = room.RoomCapacity,
                RoomDescription = room.RoomDescription,
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomToReturnDto>> GetRoom(int id)
        {
            var spec = new RoomsWithTypesAndBookingStatusesSpecification(id);
            var room = await _roomRepo.GetEntityWithSpec(spec);
            return new RoomToReturnDto
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                RoomName = room.RoomName,
                RoomMainImageUrl = room.RoomMainImageUrl,
                RoomPrice = room.RoomPrice,
                BookingStatus = room.BookingStatus.BookingStatusTitle,
                RoomType = room.RoomType.RoomTypeName,
                RoomCapacity = room.RoomCapacity,
                RoomDescription = room.RoomDescription,
            };
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