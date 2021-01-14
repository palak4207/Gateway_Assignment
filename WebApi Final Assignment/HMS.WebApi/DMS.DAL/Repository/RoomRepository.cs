using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;
        public RoomRepository(Database.HotelManagementEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.Room entity = new Database.Room();
                    
                    entity.RoomName = model.RoomName;
                    entity.RoomCategory = model.RoomCategory;
                    entity.RoomPrice = model.RoomPrice;
                    entity.IsActive = model.IsActive;
                    entity.CreatedDate = model.CreatedDate;
                    entity.CreatedBy = model.CreatedBy;
                    entity.HotelId = model.HotelId;
                    _dbContext.Rooms.Add(entity);
                    _dbContext.SaveChanges();
                    return "Successfully Added";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public IEnumerable<Room> GetAllRoombyCategory(int category)
        {
            var entities = _dbContext.Rooms.Where(e => e.RoomCategory == category).OrderBy(e => e.RoomPrice).ToList();
            List<Room> list = new List<Room>();
            if (entities.Count != 0)
            {
                foreach (var item in entities)
                {
                    var room = new Room()
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        RoomCategory = item.RoomCategory,
                        RoomPrice = item.RoomPrice,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdateDate = item.UpdateDate,
                        UpdatedBy = item.UpdatedBy
                    };
                    list.Add(room);
                }
            }
            return list;
        }

        public IEnumerable<Room> GetAllRoombyCity(string city)
        {
            var entities = _dbContext.Rooms.Where(e => e.Hotel.City == city).OrderBy(e => e.RoomPrice).ToList();
            var rooms = new List<Room>();
            if (entities.Count > 0)
            { foreach (var item in entities)
                {
                    var room = new Room()
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        RoomCategory = item.RoomCategory,
                        RoomPrice = item.RoomPrice,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy=item.CreatedBy,
                        UpdateDate=item.UpdateDate,
                        UpdatedBy=item.UpdatedBy
                    };
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public IEnumerable<Room> GetAllRoombyPinCode(int PinCode)
        {
            var entities = _dbContext.Rooms.Where(e => e.Hotel.PinCode == PinCode).OrderBy(e => e.RoomPrice).ToList();
            List<Room> list = new List<Room>();
            if(entities.Count!=0)
            { 
                foreach(var item in entities)
                {
                    var room = new Room()
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        RoomCategory = item.RoomCategory,
                        RoomPrice = item.RoomPrice,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdateDate = item.UpdateDate,
                        UpdatedBy = item.UpdatedBy
                    };
                    list.Add(room);
                }
            }
            return list;
        }

        public IEnumerable<Room> GetAllRoombyRoomPrice(float price)
        {
            var entities = _dbContext.Rooms.Where(e=>e.RoomPrice<=price).OrderBy(e => e.RoomPrice).ToList();
            List<Room> list = new List<Room>();
            if (entities.Count != 0)
            {
                foreach (var item in entities)
                {
                    var room = new Room()
                    {
                        Id = item.Id,
                        RoomName = item.RoomName,
                        RoomCategory = item.RoomCategory,
                        RoomPrice = item.RoomPrice,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CreatedBy = item.CreatedBy,
                        UpdateDate = item.UpdateDate,
                        UpdatedBy = item.UpdatedBy
                    };
                    list.Add(room);
                }
            }
            return list;
        }

        
        public bool GetRoomAvailability(int Id, DateTime date)
        {
            if (_dbContext.Rooms.Find(Id) != null)
            {
                var entity = _dbContext.Bookings.FirstOrDefault(e => e.RoomId == Id && e.BookingDate.Value.Day == date.Day &&
                (e.StastusOfBooking == (int)BookingStatus.Optional || e.StastusOfBooking == (int)BookingStatus.Definitive));

                if (entity != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
