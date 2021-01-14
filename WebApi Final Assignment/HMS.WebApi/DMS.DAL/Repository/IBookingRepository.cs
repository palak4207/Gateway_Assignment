using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
   public interface IBookingRepository
    {
        string BookRoom(Booking model);
       
        string UpdateBooking(int Id, Booking model);
        string DeleteBooking(int Id);
    }
}
