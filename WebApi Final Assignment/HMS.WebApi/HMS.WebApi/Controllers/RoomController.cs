using HMS.BAL.Interface;
using HMS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        // GET: api/Room
        public IEnumerable<Room> GetByCity(string city)
        {
            return _roomManager.GetAllRoombyCity(city);
            
        }

        public IEnumerable<Room> GetByPinCode(int PinCode)
        {
            return _roomManager.GetAllRoombyPinCode(PinCode);

        }
        public IEnumerable<Room> GetByRoomPrice(float price)
        {
            return _roomManager.GetAllRoombyRoomPrice(price);

        }

        public HttpResponseMessage GetByRoomCategory(int category)
        {
            var hotels= _roomManager.GetAllRoombyCategory(category);
            return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(hotels), Encoding.UTF8, "application/json")
                };
           

        }

        // GET: api/Room/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/room/{id:int}/availabilty")]
        public HttpResponseMessage GetAvailability(int id, DateTime date)
        {
            var availability = _roomManager.GetRoomAvailability(id, date);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {

                Content = new StringContent(availability.ToString(), Encoding.UTF8, "application/JSON")
                

            };

        }

        // POST: api/Room
        public HttpResponseMessage Post([FromBody]Room model)
        {
            var room = _roomManager.CreateRoom(model);
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Created Sucessfully", Encoding.UTF8, "application/JSON")
            };
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
