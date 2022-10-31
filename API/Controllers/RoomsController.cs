using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Errors;
using API.Services;
using Application.Services;
using AutoMapper;
using Application.Interfaces;
using Application.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Dtos;

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
        public async Task<ActionResult<IReadOnlyList<RoomToReturnDto>>> GetRooms([FromQuery] ParamsSpecification paramsSpec)
        {
            return Ok(await _roomService.GetRoomsAsync(paramsSpec));
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

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<RoomTypeToReturnDto>>> GetTypes()
        {
            return Ok(await _roomService.GetAllTypes());
        }
    }
}