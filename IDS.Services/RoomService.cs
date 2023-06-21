using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Room> CreateArtist(Room newRoom)
        {
            await _unitOfWork.Rooms
                .AddAsync(newRoom);

            return newRoom;
        }

        public Task<Room> CreateRoom(Room newRoom)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteArtist(Room room)
        {
            _unitOfWork.Rooms.Remove(room);

            await _unitOfWork.CommitAsync();
        }

        public Task DeleteRoom(Room user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _unitOfWork.Rooms.GetAllAsync();
        }

        public Task<IEnumerable<Room>> GetAllWithRoom()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _unitOfWork.Rooms.GetByIdAsync(id);
        }

        public Task<IEnumerable<Room>> GetRoomsByRoomId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRoom(Room roomToBeUpdated, Room room)
        {
            roomToBeUpdated.Name = room.Name;

            await _unitOfWork.CommitAsync();
        }

    }
}