using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{

    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string CreateRoom(Room model)
        {
            return _roomRepository.CreateRoom(model);
        }

        public IEnumerable<Room> GetAllRoombyCategory(int category)
        {
            return _roomRepository.GetAllRoombyCategory(category);
        }

        public IEnumerable<Room> GetAllRoombyCity(string city)
        {
            return _roomRepository.GetAllRoombyCity(city);
        }

        public IEnumerable<Room> GetAllRoombyPinCode(int PinCode)
        {
            return _roomRepository.GetAllRoombyPinCode(PinCode);
        }

        public IEnumerable<Room> GetAllRoombyRoomPrice(float price)
        {
            return _roomRepository.GetAllRoombyRoomPrice(price);
        }

        public bool GetRoomAvailability(int Id,DateTime date)
        {
            return _roomRepository.GetRoomAvailability(Id,date);
        }
    }
}
