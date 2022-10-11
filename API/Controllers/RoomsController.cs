using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Services;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class RoomsController : BaseApiController
    {
        private readonly IRoomService _roomService;
        
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RoomToReturnDto>>> GetRooms()
        {
            return Ok(await _roomService.GetRoomsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomToReturnDto>> GetRoom(int id)
        {
            return Ok(await _roomService.GetRoomWithSpecAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom([FromBody] RoomToCreateDto roomToCreate)
        {
            var result = await _roomService.CreateRoomAsync(roomToCreate);
            return CreatedAtAction(nameof(GetRoom), new { id = result.Id }, result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, [FromBody] RoomToUpdateDto roomToUpdate)
        {
            await _roomService.UpdateRoomAsync(id, roomToUpdate);
            return Ok(roomToUpdate);
        }
    }
}