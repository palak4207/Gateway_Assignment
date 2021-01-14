using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;
        public BookingRepository(Database.HotelManagementEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public string BookRoom(Booking model)
        {
            try
            {
                if(model!=null)
                {
                    Database.Booking entities = new Database.Booking();
                    entities.BookingDate = model.BookingDate;
                    entities.RoomId = model.RoomId;
                    entities.StastusOfBooking = 1;
                    entities.HotelId = model.HotelId;
                    _dbContext.Bookings.Add(entities);
                    _dbContext.SaveChanges();
                    return "Successfully Added";
                }
                return "Model is Null";

            }
            catch(Exception ex)
            {
                return ex.Message;

            }
        }

        public string UpdateBooking(int Id, Booking model)
        {
            var entity = _dbContext.Bookings.Find(Id);

            if (entity != null)
            {
                entity.BookingDate = model.BookingDate;
                entity.StastusOfBooking = (int)model.StastusOfBooking;
                _dbContext.SaveChanges();
                return "Updated Succesfully";
            }
            return "No Data Found";
        }



        public string DeleteBooking(int Id)
        {
            var entity = _dbContext.Bookings.Find(Id);

            if (entity != null)
            {
                entity.StastusOfBooking = (int)BookingStatus.Deleted;
                _dbContext.SaveChanges();
                return "Deleted Successfully";

            }
            return "No Data Found";
        }
    }
}
