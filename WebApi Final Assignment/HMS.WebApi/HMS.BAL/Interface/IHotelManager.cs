using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotel(int Id);

        IEnumerable<Hotel> GetAllHotel();
        string CreateHotel(Hotel model);

        string UpdateHotel(Hotel model);

        string DeleteHotel(int Id);

    }
}
