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
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public string BookRoom(Booking model)
        {
            return _bookingRepository.BookRoom(model);
        }

        public string DeleteBooking(int Id)
        {
            return _bookingRepository.DeleteBooking(Id);
        }

        public string UpdateBooking(int Id, Booking model)
        {
            return _bookingRepository.UpdateBooking(Id, model);
        }

       
    }
}
