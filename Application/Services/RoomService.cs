using Application.Dtos;
using Application.Errors;
using Application.Helpers;
using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using Application.Specifications;
using API.Services;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<RoomType> _roomTypeRepo;
        private readonly IMapper _mapper;
        public RoomService(IRepository<Room> roomRepo, IRepository<RoomType> roomTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepo = roomRepo;
            _roomTypeRepo = roomTypeRepo;
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

        public async Task<Pagination<RoomToReturnDto>> GetRoomsAsync(ParamsSpecification paramsSpec)
        {
            var spec = new RoomsWithTypesAndBookingStatusesSpecification(paramsSpec);
            var countSpec = new RoomWithFiltersForCountSpecification(paramsSpec);
            var rooms = await _roomRepo.ListAsync(spec);
            var totalCount = await _roomRepo.CountAsync(countSpec);
            var dataToReturn = _mapper.Map<IReadOnlyList<RoomToReturnDto>>(rooms);
            return new Pagination<RoomToReturnDto>(paramsSpec.PageIndex, paramsSpec.PageSize, totalCount, dataToReturn);
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

        public async Task<IReadOnlyList<RoomType>> GetAllTypes(){
            return await _roomTypeRepo.ListAllAsync();
        }
    }
}