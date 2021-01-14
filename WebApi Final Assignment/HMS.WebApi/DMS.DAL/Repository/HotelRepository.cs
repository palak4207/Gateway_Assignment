using HMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementEntities _dbContext;
        public HotelRepository(Database.HotelManagementEntities dbContext)
        {
            _dbContext = dbContext;
        }
        

        public string CreateHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                    Database.Hotel entity = new Database.Hotel();
                    entity.HotelName = model.HotelName;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.PinCode = model.PinCode;
                    entity.ContactNumber = model.ContactNumber;
                    entity.ContactPErson = model.ContactPErson;
                    entity.Website = model.Website;
                    entity.Facebook = model.Facebook;
                    entity.Twitter = model.Twitter;
                    entity.IsActive = model.IsActive;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;
                    _dbContext.Hotels.Add(entity);
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

       
        public string DeleteHotel(int Id)
        {
            throw new NotImplementedException();
        }

        
        public List<Hotel> GetAllHotel()
        {
            var entities = _dbContext.Hotels.OrderBy(x=>x.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();

            if (entities.Count!=0)
            {
                foreach(var item in entities)
                {
                    Hotel hotel = new Hotel();
                    hotel.Id = item.Id;
                    hotel.HotelName = item.HotelName;
                    hotel.Address = item.Address;
                    hotel.City = item.City;
                    hotel.PinCode = item.PinCode;
                    hotel.ContactNumber = item.ContactNumber;
                    hotel.ContactPErson = item.ContactPErson;
                    hotel.Website = item.Website;
                    hotel.Facebook = item.Facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.IsActive = item.IsActive;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.CreatedDate = item.CreatedDate;
                    hotel.UpdatedDate = item.UpdatedDate;
                    hotel.UpdatedBy = item.UpdatedBy;

                    list.Add(hotel);
                }
                
            }
            return list;
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
