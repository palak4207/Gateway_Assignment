using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public string CreateHotel(Hotel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public string DeleteHotel(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetAllHotel()
        {
            return _hotelRepository.GetAllHotel();
        }

        public Hotel GetHotel(int Id)
        {
            throw new NotImplementedException();
        }

        public string UpdateHotel(Hotel model)
        {
            throw new NotImplementedException();
        }

        
    }
}
