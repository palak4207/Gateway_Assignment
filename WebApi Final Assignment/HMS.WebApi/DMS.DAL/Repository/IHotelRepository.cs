using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public interface IHotelRepository
    {
        Hotel GetHotel(int Id);

        List<Hotel> GetAllHotel();
        string CreateHotel(Hotel model);

        string UpdateHotel(Hotel model);

        string DeleteHotel(int Id);

    }
}
