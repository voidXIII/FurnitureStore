using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IMapper _mapper;
        public RoomService(IRepository<Room> roomRepo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepo = roomRepo;
        }
        public async Task<RoomToReturnDto> CreateRoomAsync(RoomToCreateDto roomToCreate)
        {
            var room = new Room
            {
                RoomNumber = roomToCreate.RoomNumber,
                RoomName = roomToCreate.RoomName,
                RoomMainImageUrl = roomToCreate.RoomMainImageUrl,
                RoomPrice = roomToCreate.RoomPrice,
                BookingStatusId = roomToCreate.BookingStatusId,
                RoomTypeId = roomToCreate.RoomTypeId,
                RoomCapacity = roomToCreate.RoomCapacity,
                RoomDescription = roomToCreate.RoomDescription
            };

            var roomToUpload = _mapper.Map(roomToCreate, room);
            _roomRepo.Add(roomToUpload);
            await _roomRepo.SaveChangesAsync();
            return _mapper.Map<RoomToReturnDto>(roomToUpload);
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _roomRepo.GetByIdAsync(id);

            if(room == null)
            {
                throw NotFoundException.OfType<Room>(id);
            }
            await _roomRepo.DeleteAsync(id);
            await _roomRepo.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<RoomToReturnDto>> GetRoomsAsync()
        {
            var spec = new RoomsWithTypesAndBookingStatusesSpecification();
            var rooms = await _roomRepo.ListAsync(spec);
            return _mapper.Map<IReadOnlyList<RoomToReturnDto>>(rooms);
        }

        public async Task<RoomToReturnDto> GetRoomWithSpecAsync(int id)
        {
            var spec = new RoomsWithTypesAndBookingStatusesSpecification(id);
            var room = await _roomRepo.GetEntityWithSpec(spec);
            if(room == null)
            {
                throw NotFoundException.OfType<Room>(id);
            }
            return _mapper.Map<RoomToReturnDto>(room);
        }

        public async Task UpdateRoomAsync(int id, RoomToUpdateDto roomToUpdate)
        {
            var room = await _roomRepo.GetByIdAsync(id);
            if(room == null)
            {
                throw NotFoundException.OfType<Room>(id);
            }
            var dataToUpdate = _mapper.Map(roomToUpdate, room);
            _roomRepo.Update(dataToUpdate);
            await _roomRepo.SaveChangesAsync();
        }
    }
}